using System;

namespace CustomPause.Simple
{
    public abstract class Singleton<T> where T : class, new()
    {
        public static T Instance => _lazyInstance.Value;
    
        private static readonly Lazy<T> _lazyInstance = new Lazy<T>(() => new T());
    }
}