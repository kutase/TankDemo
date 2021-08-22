using UnityEngine;

namespace TankDemo
{
    public class TankHealth : CommonHealth
    {
        public override void Die()
        {
            // todo: show Game over screen
            Debug.LogWarning("Tank is dead!");
        }
    }
}