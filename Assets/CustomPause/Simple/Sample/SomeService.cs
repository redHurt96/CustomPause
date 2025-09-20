using System;
using UnityEngine;

namespace CustomPause.Simple.Sample
{
    public class SomeService : IPauseTickable
    {
        public void Tick()
        {
            Debug.Log("SomeService Tick");
        }
    }
}