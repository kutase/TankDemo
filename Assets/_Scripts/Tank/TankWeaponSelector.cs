using System.Collections.Generic;
using UnityEngine;

namespace TankDemo
{
    public class TankWeaponSelector : MonoBehaviour, ITankWeaponSelector
    {
        [SerializeField]
        private List<CommonTankWeapon> weapons;

        private int currentWeaponIndex = 0;

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