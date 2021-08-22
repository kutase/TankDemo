using Zenject;

namespace TankDemo
{
    public class DIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Tank>().FromComponentInHierarchy().AsSingle();
        }
    }
}