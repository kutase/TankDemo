using UnityEngine;
using UnityEngine.Events;

namespace TankDemo
{
    public class Bullet : MonoBehaviour, IResettable, IRemoveEventProvider
    {
        [SerializeField]
        private float maxFlyDistance = 20f;
        
        private float speed;
        private float damage;

        private bool isBroken = false;

        private Vector3 startPosition;

        private UnityEvent onRemoveEvent = new UnityEvent();
        public UnityEvent OnRemoveEvent => onRemoveEvent;

        public void SetData(float speed, float damage)
        {
            this.speed = speed;
            this.damage = damage;
            
            startPosition = transform.position;
        }

        void FixedUpdate()
        {
            if (isBroken)
            {
                return;
            }

            transform.position += transform.forward.normalized * (speed * Time.fixedDeltaTime);

            if (Vector3.Distance(startPosition, transform.position) > maxFlyDistance)
            {
                isBroken = true;
                onRemoveEvent.Invoke();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (isBroken)
            {
                return;
            }

            var health = other.gameObject.GetComponent<IHealth>();
            health?.TakeDamage(damage);

            onRemoveEvent.Invoke();

            isBroken = true;
        }

        public void ResetState()
        {
            isBroken = false;
        }
    }
}
