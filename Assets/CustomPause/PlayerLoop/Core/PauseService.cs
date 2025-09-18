using System.Collections.Generic;
using CustomPause.Zenject.Core;

namespace CustomPause.PlayerLoop.Core
{
    public class PauseService : IPauseService
    {
        public bool IsPaused { get; private set; }
        
        private readonly List<IPauseTickable> _pauseTickables = new();

        internal void Update()
        {
            if (IsPaused)
                return;
            
            foreach (IPauseTickable pauseTickable in _pauseTickables)
                pauseTickable.Tick();
        }

        public void Pause() => 
            IsPaused = true;

        public void Resume() => 
            IsPaused = false;

        public void Register(IPauseTickable pauseTickable) => 
            _pauseTickables.Add(pauseTickable);

        public void Unregister(IPauseTickable pauseTickable) => 
            _pauseTickables.Remove(pauseTickable);
    }
}