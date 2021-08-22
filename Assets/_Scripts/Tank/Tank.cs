using System.Collections.Generic;
using UnityEngine;

namespace TankDemo
{
    public class Tank : MonoBehaviour, ITransformProvider
    {
        private TankInput input;

        public Transform Transform => transform;

        private void Awake()
        {
            var movement = GetComponent<IMovement>();
            var characterController = GetComponent<CharacterController>();
            var weaponSelector = GetComponent<ITankWeaponSelector>();

            input = new TankInput(characterController, transform, movement, weaponSelector);
        }

        private void Update()
        {
            input.Tick(Time.fixedDeltaTime);
        }
    }
}
