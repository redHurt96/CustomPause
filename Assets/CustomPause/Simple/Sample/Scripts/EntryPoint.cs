using UnityEngine;

namespace CustomPause.Simple.Sample
{
    public class EntryPoint : MonoBehaviour
    {
        private SomeService _someService;

        private void Start()
        {
            _someService = new SomeService();
            PauseService.Instance.Register(_someService);
        }

        private void OnDestroy()
        {
            PauseService.Instance.Unregister(_someService);
        }
    }
}
