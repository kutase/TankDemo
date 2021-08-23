using UnityEngine;

namespace TankDemo
{
    public interface IMovement
    {
        float Velocity { get; }
        float RotationSpeed { get; }

        void Move(CharacterController controller, float direction = 1f);
        void Rotate(Transform transform, float direction);
    }
}
