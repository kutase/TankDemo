using UnityEngine;

namespace TankDemo
{
    public class EnemyAI : IEnemyAI
    {
        private IEnemyMovement movement;
        private IDamageInfo damageInfo;
        private Transform transform;
        private Transform target;

        public EnemyAI(IEnemyMovement movement, IDamageInfo damageInfo, Transform transform, Transform target)
        {
            this.movement = movement;
            this.damageInfo = damageInfo;
            this.transform = transform;
            this.target = target;
        }

        public void CalculateAI()
        {
            var currentPosition = transform.position;
            var targetPosition = target.position;

            var delta = (targetPosition - currentPosition).normalized;
            var cross = Vector3.Cross(delta, transform.forward);

            movement.Rotate(transform, -cross.y);

            if (Vector3.Distance(currentPosition, targetPosition) > 2f)
            {
                movement.Move(transform);
            }
            else
            {
                var targetHealth = target.GetComponent<IHealth>();
                targetHealth?.TakeDamage(damageInfo.Damage);
            }
        }
    }
}
