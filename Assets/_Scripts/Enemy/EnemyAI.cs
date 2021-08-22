using UnityEngine;

namespace TankDemo
{
    public class EnemyAI : IEnemyAI
    {
        private IMovement movement;
        private IDamageInfo damageInfo;
        private Transform transform;
        private Transform target;
        private CharacterController characterController;

        public EnemyAI(IMovement movement, IDamageInfo damageInfo, CharacterController characterController, Transform target)
        {
            this.movement = movement;
            this.damageInfo = damageInfo;
            this.characterController = characterController;
            this.target = target;
        }

        public void CalculateAI()
        {
            var currentPosition = characterController.transform.position;
            var targetPosition = target.position;

            var delta = (targetPosition - currentPosition).normalized;
            var cross = Vector3.Cross(delta, characterController.transform.forward);

            movement.Rotate(characterController.transform, -cross.y);

            if (Vector3.Distance(currentPosition, targetPosition) > 2f)
            {
                movement.Move(characterController);
            }
            else
            {
                var targetHealth = target.GetComponent<IHealth>();
                targetHealth?.TakeDamage(damageInfo.Damage);
            }
        }
    }
}
