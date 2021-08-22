using UnityEngine;
using UnityEngine.Events;

namespace TankDemo
{
    public class CommonHealth : MonoBehaviour, IHealth, IResettable
    {
        [SerializeField]
        private float health;
        public float Health => health;

        private float initialHealth;

        [SerializeField]
        [Range(0f, 1f)]
        private float defence = 1f;
        public float Defence => defence;

        private float protectedTime = 1f;
        public float ProtectedTime => protectedTime;

        private float lastAttackTime = 0f;

        public bool IsDead => health <= 0f;

        private bool canAttack = true;
        public bool CanAttack => canAttack;
        
        private void Awake()
        {
            initialHealth = health;
        }
 
        public virtual void TakeDamage(float damage)
        {
            if (IsDead)
            {
                return;
            }

            if (!canAttack)
            {
                if (Time.time < lastAttackTime + ProtectedTime)
                {
                    return;
                }
                else
                {
                    canAttack = true;
                }
            }

            health -= damage * defence;
            health = Mathf.Max(health, 0f);

            lastAttackTime = Time.time;
            canAttack = false;

            if (IsDead)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Destroy(gameObject);
        }

        public virtual void ResetState()
        {
            health = initialHealth;
            lastAttackTime = 0f;
        }
    }
}
