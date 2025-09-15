using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace CustomPause.Zenject.Core
{
    /*
        private const int PLAYER_LOOP_INDEX = 5; // Update
     
     * PlayerLoopSystem loop = PlayerLoop.GetCurrentPlayerLoop();
            loop.subSystemList[PLAYER_LOOP_INDEX].subSystemList = loop.subSystemList[PLAYER_LOOP_INDEX].subSystemList
                .Where(x => x.type != GetType())
                .ToArray();
     */

    internal class PauseService : IPauseService, ITickable
    {
        public bool IsPaused { get; private set; }
        
        private readonly List<IPauseTickable> _pauseTickable;

        public PauseService(IPauseTickable[] pauseTickable)
        {
            _pauseTickable = pauseTickable.ToList();
        }

        public void Tick()
        {
            if (IsPaused)
                return;
            
            foreach (IPauseTickable pauseTickable in _pauseTickable)
                pauseTickable.Tick();
        }

        public void Pause() => 
            IsPaused = true;

        public void Resume() => 
            IsPaused = false;

        internal void Register(IPauseTickable pauseTickable) => 
            _pauseTickable.Add(pauseTickable);

        internal void Unregister(IPauseTickable pauseTickable) => 
            _pauseTickable.Remove(pauseTickable);
    }
}