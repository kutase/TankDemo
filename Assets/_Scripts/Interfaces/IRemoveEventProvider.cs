using UnityEngine.Events;

namespace TankDemo
{
    public interface IRemoveEventProvider
    {
        UnityEvent OnRemoveEvent { get; }
    }
}
