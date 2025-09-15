using UnityEngine;
using Zenject;

namespace CustomPause.Zenject.Core
{
    internal class Creator : ICreator
    {
        private readonly IInstantiator _instantiator;
        private readonly PauseService _pauseService;

        public Creator(IInstantiator instantiator, PauseService pauseService)
        {
            _instantiator = instantiator;
            _pauseService = pauseService;
        }

        public T Create<T>(T prefab) where T : MonoBehaviour, IPauseTickable
        {
            GameObject pauseTickable = _instantiator.InstantiatePrefab(prefab);
            T pauseTickableComponent = pauseTickable.GetComponent<T>();
            
            _pauseService.Register(pauseTickableComponent);
            
            return pauseTickableComponent;
        }
    }
}