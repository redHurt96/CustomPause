using Zenject;

namespace CustomPause.Zenject.Core
{
    internal class PauseAdapter : IInitializable
    {
        private readonly IPauseTickable[] _pauseTickables;
        private readonly PauseService _pauseService;

        public PauseAdapter(IPauseTickable[] pauseTickables, PauseService pauseService)
        {
            _pauseTickables = pauseTickables;
            _pauseService = pauseService;
        }

        public void Initialize()
        {
            foreach (var pauseTickable in _pauseTickables)
                _pauseService.Register(pauseTickable);
        }
    }
}