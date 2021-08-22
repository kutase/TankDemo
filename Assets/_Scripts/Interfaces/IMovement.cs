using UnityEngine;

namespace TankDemo
{
    public interface IMovement
    {
        float Velocity { get; }
        float RotationSpeed { get; }

        void Rotate(Transform transform, float direction);
    }
}
