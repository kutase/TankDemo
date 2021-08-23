using UnityEngine;

namespace TankDemo
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private float damage;
        public float Damage => damage;
    }
}
