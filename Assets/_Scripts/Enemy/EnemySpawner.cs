using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TankDemo
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject(Id = "EnemiesPool")]
        private IObjectPool EnemiesPool;

        [SerializeField]
        private float spawnRadius;

        [SerializeField]
        private int targetEnemiesCount = 10;

        private int currentEnemiesCount = 0;

        private Coroutine spawningCoroutine;

        private void Start()
        {
            StartSpawning();
        }

        public void StartSpawning()
        {
            spawningCoroutine = StartCoroutine(SpawningProcess());
        }

        public void StopSpawning()
        {
            StopCoroutine(spawningCoroutine);
        }

        private IEnumerator SpawningProcess()
        {
            while (true)
            {
                if (currentEnemiesCount < targetEnemiesCount)
                {
                    var enemy = SpawnEnemy();
                    var enemyDeathEvent = enemy.GetComponent<IRemoveEventProvider>().OnRemoveEvent;

                    enemyDeathEvent.RemoveListener(OnEnemyDeath);
                    enemyDeathEvent.AddListener(OnEnemyDeath);

                    currentEnemiesCount++;
                }

                yield return new WaitForSeconds(0.5f);
            }
        }

        private GameObject SpawnEnemy()
        {
            return EnemiesPool.CreateAny(
                Quaternion.Euler(0f, Random.Range(0, 360f), 0f) * (Vector3.forward * spawnRadius),
                Quaternion.identity
            );
        }

        private void OnEnemyDeath()
        {
            currentEnemiesCount--;
        }
    }
}