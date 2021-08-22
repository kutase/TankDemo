using System.Collections.Generic;
using UnityEngine;

namespace TankDemo
{
    public class Tank : MonoBehaviour, ITankWeaponSelector
    {
        private IHealth health;
        private ITankMovement movement;
        private CharacterController characterController;

        [SerializeField] private List<CommonTankWeapon> weapons;

        private int currentWeaponIndex = 0;

        private TankInput input;

        private void Awake()
        {
            health = GetComponent<IHealth>();
            movement = GetComponent<ITankMovement>();
            characterController = GetComponent<CharacterController>();

            input = new TankInput(characterController, transform, movement, this);
        }

        private void FixedUpdate()
        {
            input.Tick(Time.fixedDeltaTime);
        }

        public ITankWeapon SetNextWeapon()
        {
            var currentWeapon = weapons[currentWeaponIndex];
            currentWeapon.Deactivate();

            currentWeaponIndex++;

            if (currentWeaponIndex > weapons.Count - 1)
            {
                currentWeaponIndex = 0;
            }

            currentWeapon = weapons[currentWeaponIndex];
            currentWeapon.Activate();

            return currentWeapon;
        }

        public ITankWeapon SetPrevWeapon()
        {
            var currentWeapon = weapons[currentWeaponIndex];
            currentWeapon.Deactivate();

            currentWeaponIndex--;

            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Count - 1;
            }

            currentWeapon = weapons[currentWeaponIndex];
            currentWeapon.Activate();

            return currentWeapon;
        }

        public ITankWeapon GetCurrentWeapon()
        {
            return weapons[currentWeaponIndex];
        }
    }
}
