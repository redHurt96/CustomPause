using UnityEngine;

namespace AwfulVariant.Logic
{
    internal class PauseService
    {
        public void Enable()
        {
            Time.timeScale = 0f;
        }
        
        public void Disable()
        {
            Time.timeScale = 1f;
        }
    }
}