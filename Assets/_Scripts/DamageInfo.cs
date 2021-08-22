using UnityEngine;

namespace TankDemo
{
    public class DamageInfo : MonoBehaviour, IDamageInfo
    {
        [SerializeField]
        private float damage;
        public float Damage => damage;
    }
}
