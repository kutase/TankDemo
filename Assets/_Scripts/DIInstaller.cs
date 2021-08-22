using TankDemo;
using UnityEngine;
using Zenject;

namespace TankDemo
{
    public class DIInstaller : MonoInstaller
    {
        [SerializeField]
        private Tank Tank;
        
        [SerializeField]
        private CommonPool BulletsPool;

        [SerializeField]
        private CommonPool EnemiesPool;

        public override void InstallBindings()
        {
            Container.Bind<Tank>().FromInstance(Tank).AsSingle();
            Container.Bind<CommonPool>().WithId("BulletsPool").FromInstance(BulletsPool);
            Container.Bind<CommonPool>().WithId("EnemiesPool").FromInstance(EnemiesPool);
        }
    }
}
