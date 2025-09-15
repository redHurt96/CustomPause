using CustomPause.Zenject.Core;
using UnityEngine;

namespace CustomPause.Zenject.Sample
{
    public class TestService : IPauseTickable
    {
        public void Tick()
        {
            Debug.Log("TestService Tick");
        }
    }
}