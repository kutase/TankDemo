using UnityEngine;
using UnityEngine.Events;

namespace TankDemo
{
    public class CommonHealth : MonoBehaviour, IHealth, IResettable
    {
        private const float DEFAULT_RESIST_TIME = 1f;

        private const float MIN_DEFENCE_VALUE = 0f;
        private const float MAX_DEFENCE_VALUE = 1f;

        [SerializeField]
        private float health;
        public float Health => health;

        private float initialHealth;

        [SerializeField]
        [Range(MIN_DEFENCE_VALUE, MAX_DEFENCE_VALUE)]
        private float defence = MAX_DEFENCE_VALUE;
        public float Defence => defence;

        [SerializeField]
        private float attackResistTime = DEFAULT_RESIST_TIME;
        public float AttackResistTime => attackResistTime;

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

            if (CheckResistState())
            {
                return;
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

        private bool CheckResistState()
        {
            if (!canAttack)
            {
                // is resisting
                if (Time.time < lastAttackTime + AttackResistTime)
                {
                    return true;
                }
                else
                {
                    canAttack = true;
                }
            }

            return false;
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
