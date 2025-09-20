using UnityEngine;

namespace CustomPause.Simple.Sample
{
    public abstract class PauseMonoBehaviour : MonoBehaviour, IPauseTickable
    {
        private void Awake()
        {
            PauseService.Instance.Register(this);
            AwakeInternal();
        }
        
        private void OnDestroy()
        {
            PauseService.Instance.Unregister(this);
            OnDestroyInternal();
        }

        public abstract void Tick();
        
        protected virtual void AwakeInternal() {}
        protected virtual void OnDestroyInternal() {}
    }
}