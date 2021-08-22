using System;
using UnityEngine;

namespace TankDemo
{
    public class TankMovement : MonoBehaviour, IMovement
    {
        [SerializeField]
        private float velocity;
        public float Velocity => velocity;

        [SerializeField]
        private float rotationSpeed;
        public float RotationSpeed => rotationSpeed;

        public void Move(CharacterController controller, float direction = 1f)
        {
            controller.Move(transform.forward.normalized * (direction * velocity * Time.fixedDeltaTime));

            var tankTransform = controller.transform;

            var tankPosition = tankTransform.position;
            tankPosition.y = 0f;
            tankTransform.position = tankPosition;
        }

        public void Rotate(Transform transform, float direction)
        {
            transform.Rotate(Vector3.up, direction * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
