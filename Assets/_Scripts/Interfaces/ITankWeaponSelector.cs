namespace TankDemo
{
    public interface ITankWeaponSelector
    {
        ITankWeapon SetNextWeapon();
        ITankWeapon SetPrevWeapon();
        ITankWeapon GetCurrentWeapon();
    }
}
