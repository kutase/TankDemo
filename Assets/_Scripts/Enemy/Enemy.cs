using UnityEngine;
using Zenject;

namespace TankDemo
{
    public class Enemy : MonoBehaviour
    {
        private IEnemyMovement movement;
        private IHealth health;
        private IEnemyAI enemyAi;

        [Inject]
        private Tank target;

        private void Awake()
        {
            movement = GetComponent<IEnemyMovement>();
            health = GetComponent<IHealth>();

            var damageInfo = GetComponent<IDamageInfo>();

            enemyAi = new EnemyAI(movement, damageInfo, transform, target.transform);
        }

        private void FixedUpdate()
        {
            enemyAi.CalculateAI();
        }
    }
}
