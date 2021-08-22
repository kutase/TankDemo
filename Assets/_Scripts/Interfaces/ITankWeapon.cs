namespace TankDemo
{
    public interface ITankWeapon : IDamageInfo
    {
        bool CanShoot { get; }

        float ReloadTime { get; }

        void Shoot();
        void Activate();
        void Deactivate();
    }
}
