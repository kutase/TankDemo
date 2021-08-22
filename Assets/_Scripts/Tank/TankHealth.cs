using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace TankDemo
{
    public class TankHealth : CommonHealth
    {
        [Inject(Id = "TankHealthChangedEvent")]
        private UnityEvent tankHealthChangedEvent;

        [Inject(Id = "GameOverEvent")]
        private UnityEvent gameOverEvent;

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            tankHealthChangedEvent.Invoke();
        }

        public override void ResetState()
        {
            base.ResetState();
            tankHealthChangedEvent.Invoke();
        }

        public override void Die()
        {
            // todo: show Game over screen
            Debug.LogWarning("Tank is dead!");
            gameOverEvent.Invoke();
        }
    }
}
