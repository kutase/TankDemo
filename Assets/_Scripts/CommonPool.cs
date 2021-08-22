using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TankDemo
{
    public class CommonPool : MonoBehaviour, IObjectPool
    {
        [SerializeField]
        private int preInstantiateNumber = 10;

        [SerializeField]
        private List<GameObject> prefabVariants;

        private Dictionary<string, List<GameObject>> pooledObjects = new Dictionary<string, List<GameObject>>();

        [Inject]
        private DiContainer container;

        private void Awake()
        {
            foreach (var prefab in prefabVariants)
            {
                pooledObjects[prefab.name] = new List<GameObject>();

                for (int i = 0; i < preInstantiateNumber; i++)
                {
                    var poolObject = InstantiateAndPrepareObject(prefab);

                    pooledObjects[prefab.name].Add(poolObject);
                }
            }
        }

        private GameObject InstantiateAndPrepareObject(GameObject prefab)
        {
            var poolObject = container.InstantiatePrefab(prefab, transform);

            poolObject.SetActive(false);

            var removeEventProvider = poolObject.GetComponent<IRemoveEventProvider>();
            if (removeEventProvider != null)
            {
                removeEventProvider.OnRemoveEvent.AddListener(() =>
                {
                    Remove(poolObject);
                });
            }

            return poolObject;
        }

        public GameObject Create(string prefabId, Vector3 position, Quaternion rotation)
        {
            var pooledObjectsList = pooledObjects[prefabId];

            foreach (var pooledObject in pooledObjectsList)
            {
                if (!pooledObject.activeInHierarchy)
                {
                    pooledObject.transform.SetPositionAndRotation(position, rotation);

                    var resetter = pooledObject.GetComponent<IResettable>();
                    resetter?.ResetState();

                    pooledObject.SetActive(true);
                    return pooledObject;
                }
            }

            var prefab = prefabVariants.Find(it => it.name == prefabId);

            var poolObject = InstantiateAndPrepareObject(prefab);

            return poolObject;
        }

        public GameObject CreateAny(Vector3 position, Quaternion rotation)
        {
            var prefab = prefabVariants[Random.Range(0, prefabVariants.Count)];

            return Create(prefab.name, position, rotation);
        }

        public void Remove(GameObject poolObject)
        {
            poolObject.SetActive(false);
        }
    }
}
