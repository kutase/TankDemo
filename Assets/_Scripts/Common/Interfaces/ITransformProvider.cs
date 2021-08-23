using UnityEngine;

namespace TankDemo
{
    public interface ITransformProvider
    {
        Transform Transform { get; }
    }
}