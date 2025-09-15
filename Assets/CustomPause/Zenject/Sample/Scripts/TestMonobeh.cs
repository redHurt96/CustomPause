using CustomPause.Zenject.Core;
using UnityEngine;

namespace CustomPause.Zenject.Sample
{
    public class TestMonobeh : MonoBehaviour, IPauseTickable
    {
        public void Tick()
        {
            Debug.Log("TestService Tick from MonoBehaviour");
        }
    }
}