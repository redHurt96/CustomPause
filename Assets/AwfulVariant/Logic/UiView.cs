using UnityEngine;
using UnityEngine.UI;

namespace AwfulVariant.Logic
{
    internal class UiView : MonoBehaviour
    {
        public Button Button;

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}