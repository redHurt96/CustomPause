using UnityEngine;

namespace CustomPause.Simple
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }
        
        private void Awake()
        {
            Instance = this as T;
        }
    }
}