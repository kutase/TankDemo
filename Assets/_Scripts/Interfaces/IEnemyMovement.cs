using UnityEngine;

namespace TankDemo
{
    public interface IEnemyMovement : IMovement
    {
        void Move(Transform transform, float direction = 1f);
    }
}
