using UnityEngine;

namespace CustomPause.Zenject.Core
{
    public interface ICreator
    {
        T Create<T>(T prefab) where T : MonoBehaviour, IPauseTickable;
    }
}