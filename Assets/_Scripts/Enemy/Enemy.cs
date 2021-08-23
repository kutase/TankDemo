using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace TankDemo
{
    public class Enemy : MonoBehaviour, IResettable
    {
        private IMovement movement;
        private IHealth health;
        private IEnemyAI enemyAi;

        [Inject(Id = "Tank")]
        private ITransformProvider target;

        private void Awake()
        {
            movement = GetComponent<IMovement>();
            health = GetComponent<IHealth>();

            var damageInfo = GetComponent<IDamageable>();
            var characterController = GetComponent<CharacterController>();

            enemyAi = new EnemyAI(movement, damageInfo, characterController, target.Transform);
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
