using UnityEngine;

namespace CustomPause.Simple.Sample
{
    public class SomeMonoBehaviour : PauseMonoBehaviour
    {
        public override void Tick()
        {
            Debug.Log("SomeMonoBehaviour Tick");
        }
    }
}