using UnityEngine;

namespace CustomPause.Simple.Sample
{
    public class PauseInteractor : MonoBehaviour
    {
        private PauseService _pauseService;

        private void Start()
        {
            _pauseService = PauseService.Instance;
        }

        private void Update()
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
                var gameObject = new GameObject();
                gameObject.AddComponent<SomeMonoBehaviour>();
            }
        }
    }
}