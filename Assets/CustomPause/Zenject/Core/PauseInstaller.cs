using Zenject;

namespace CustomPause.Zenject.Core
{
    internal class PauseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PauseService>().AsSingle(); //use "ToSelf" method is important for ICreator
            Container.BindInterfacesTo<Creator>().AsSingle();
            Container.BindInterfacesTo<PauseAdapter>().AsSingle();
        }
    }
}

