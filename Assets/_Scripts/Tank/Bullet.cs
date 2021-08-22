using UnityEngine;

namespace TankDemo
{
    public class Bullet : MonoBehaviour
    {
        private float speed;
        private float damage;

        private bool isBroken = false;

        public void SetData(float speed, float damage)
        {
            this.speed = speed;
            this.damage = damage;
        }

        void FixedUpdate()
        {
            transform.position += transform.forward.normalized * (speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (isBroken)
            {
                return;
            }

            var health = other.gameObject.GetComponent<IHealth>();
            health?.TakeDamage(damage);

            Destroy(gameObject);

            isBroken = true;
        }
    }
}
