using CustomPause.Zenject.Core;
using UnityEngine;
using Zenject;

namespace CustomPause.Zenject.Sample
{
    public class PauseInteractor : ITickable
    {
        private readonly IPauseService _pauseService;
        private readonly ICreator _creator;
        private readonly TestMonobeh _prefab;

        public PauseInteractor(IPauseService pauseService, ICreator creator, TestMonobeh prefab)
        {
            _pauseService = pauseService;
            _creator = creator;
            _prefab = prefab;
        }
        
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                _pauseService.Pause();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _pauseService.Resume();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                _creator.Create(_prefab);
            }
        }
    }
}