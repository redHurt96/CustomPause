using UnityEngine;
using Zenject;

namespace CustomPause.Zenject.Sample
{
    internal class TestInstaller : MonoInstaller
    {
        [SerializeField] private TestMonobeh _testMonobeh;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PauseInteractor>().AsSingle().WithArguments(_testMonobeh);
            Container.BindInterfacesTo<TestService>().AsSingle();
        }
    }
}