using System.Collections.Generic;
using UnityEngine;

namespace TankDemo
{
    public class Tank : MonoBehaviour, ITransformProvider
    {
        private TankInput input;
        private IHealth health;

        public Transform Transform => transform;

        private void Awake()
        {
            health = GetComponent<IHealth>();

            var movement = GetComponent<IMovement>();
            var characterController = GetComponent<CharacterController>();
            var weaponSelector = GetComponent<ITankWeaponSelector>();

            input = new TankInput(characterController, transform, movement, weaponSelector);
        }

        private void Update()
        {
            if (health.IsDead)
            {
                return;
            }

            input.Tick(Time.fixedDeltaTime);
        }
    }
}
