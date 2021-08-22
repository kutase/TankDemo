using System;
using UnityEngine;

namespace TankDemo
{
    public class CommonTankWeapon : MonoBehaviour, ITankWeapon
    {
        [SerializeField]
        private Vector3 offset;

        private bool canShoot = true;
        public bool CanShoot => canShoot;

        [SerializeField]
        private float reloadTime;
        public float ReloadTime => reloadTime;

        [SerializeField]
        private float damage;
        public float Damage => damage;

        [SerializeField]
        private float bulletSpeed;

        public GameObject BulletPrefab;

        private float lastShotTime = 0f;

        public void Shoot()
        {
            if (Time.time - lastShotTime > reloadTime)
            {
                var bullet = Instantiate(
                        BulletPrefab,
                        transform.position + (transform.rotation * offset),
                        transform.rotation
                    )
                    .GetComponent<Bullet>();

                bullet.SetData(bulletSpeed, damage);

                lastShotTime = Time.time;
            }
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position + (transform.rotation * offset), 0.1f);
        }
    }
}
