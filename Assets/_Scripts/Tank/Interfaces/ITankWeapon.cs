namespace TankDemo
{
    public interface ITankWeapon : IDamageable
    {
        bool CanShoot { get; }

        float ReloadTime { get; }

        void Shoot();
        void Activate();
        void Deactivate();
    }
}
