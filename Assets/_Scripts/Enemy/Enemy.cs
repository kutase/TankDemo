using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace TankDemo
{
    public class Enemy : MonoBehaviour, IRemoveEventProvider, IResettable
    {
        private IEnemyMovement movement;
        private IHealth health;
        private IEnemyAI enemyAi;

        private UnityEvent onRemoveEvent = new UnityEvent();
        public UnityEvent OnRemoveEvent => onRemoveEvent;

        [Inject]
        private Tank target;
        
        [Inject(Id = "BulletsPool")]
        private CommonPool bulletsPool;

        private void Start()
        {
            Debug.Log($"target: {target} {bulletsPool}");

            movement = GetComponent<IEnemyMovement>();
            health = GetComponent<IHealth>();

            var damageInfo = GetComponent<IDamageInfo>();

            enemyAi = new EnemyAI(movement, damageInfo, transform, target.transform);
        }

        private void FixedUpdate()
        {
            enemyAi.CalculateAI();
        }

        public void ResetState()
        {
            var resettables = GetComponentsInChildren<IResettable>();
            foreach (var resettable in resettables)
            {
                if (resettable != ((IResettable)this))
                {
                    resettable.ResetState();
                }
            }
        }
    }
}
