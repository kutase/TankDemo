using UnityEngine.Events;

namespace TankDemo
{
    public interface IChangeEventProvider
    {
        UnityEvent OnChangeEvent { get; }
    }
}