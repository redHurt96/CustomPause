namespace CustomPause.Zenject.Core
{
    public interface IPauseService
    {
        bool IsPaused { get; }
        void Pause();
        void Resume();
    }
}