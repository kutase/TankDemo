namespace TankDemo
{
    public interface IHealth
    {
        float Health { get; }
        float Defence { get; }
        float AttackResistTime { get; }
        bool IsDead { get; }
        bool CanAttack { get; }

        void TakeDamage(float damage);
        void Die();
    }
}
