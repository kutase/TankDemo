using UnityEngine;

namespace TankDemo
{
    public interface IObjectPool
    {
        GameObject Create(string prefabId, Vector3 position, Quaternion rotation);
        void Remove(GameObject gameObject);
    }
}
