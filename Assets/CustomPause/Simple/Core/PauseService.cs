using System.Collections.Generic;

namespace CustomPause.Simple
{
    public class PauseService : Singleton<PauseService>
    {
        public bool IsPaused { get; private set; }
        
        private readonly List<IPauseTickable> _pauseTickable;

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
    
    public abstract class PausableMonoBehaviour : UnityEngine.MonoBehaviour, IPauseTickable
    {
        protected virtual void OnEnable() => 
            PauseService.Instance.Register(this);

        protected virtual void OnDisable() => 
            PauseService.Instance.Unregister(this);

        public abstract void Tick();
    }
}