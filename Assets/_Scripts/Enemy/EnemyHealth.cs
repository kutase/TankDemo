using UnityEngine;
using UnityEngine.Events;

namespace TankDemo
{
    public class EnemyHealth : CommonHealth, IRemoveEventProvider
    {
        private UnityEvent onRemoveEvent = new UnityEvent();
        public UnityEvent OnRemoveEvent => onRemoveEvent;

        public override void Die()
        {
            onRemoveEvent.Invoke();
        }
    }
}