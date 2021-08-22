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
            Container.Bind<ITransformProvider>().WithId("Tank").FromInstance(Tank).AsCached().NonLazy();
            Container.Bind<EnemySpawner>().FromComponentInHierarchy().AsSingle().NonLazy();;
            Container.Bind<IObjectPool>().WithId("BulletsPool").FromInstance(BulletsPool).AsCached().NonLazy();;
            Container.Bind<IObjectPool>().WithId("EnemiesPool").FromInstance(EnemiesPool).AsCached().NonLazy();;
        }
    }
}
