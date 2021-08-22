using UnityEngine;

namespace TankDemo
{
    public class TankInput : ITickable
    {
        private IMovement movement;
        private Transform transform;
        private CharacterController characterController;
        private ITankWeaponSelector weaponSelector;
        private ITankWeapon weapon;

        public TankInput(
                CharacterController characterController,
                Transform transform,
                IMovement movement,
                ITankWeaponSelector weaponSelector
            )
        {
            this.transform = transform;
            this.characterController = characterController;
            this.movement = movement;
            this.weaponSelector = weaponSelector;

            weapon = weaponSelector.GetCurrentWeapon();
        }

        public void Tick(float dt)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movement.Move(characterController);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movement.Move(characterController, -1f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                movement.Rotate(transform, 1f);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement.Rotate(transform, -1f);
            }

            if (Input.GetKey(KeyCode.X))
            {
                weapon.Shoot();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                weapon = weaponSelector.SetPrevWeapon();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                weapon = weaponSelector.SetNextWeapon();
            }
        }
    }
}
