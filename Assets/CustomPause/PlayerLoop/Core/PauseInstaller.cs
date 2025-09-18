using System;
using System.Linq;
using UnityEngine;
using UnityEngine.LowLevel;
using Zenject;

namespace CustomPause.PlayerLoop.Core
{
    public class PauseInstaller : MonoBehaviour
    {
        private const int PLAYER_LOOP_INDEX = 5; // Update

        private void Awake()
        {
            PauseService pauseService = new();
            PlayerLoopSystem loop = UnityEngine.LowLevel.PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopSystem sys = new()
            {
                type = typeof(PauseService),
                updateDelegate = () => pauseService.Update(),
            };
            
            loop.subSystemList[PLAYER_LOOP_INDEX].subSystemList = loop.subSystemList[PLAYER_LOOP_INDEX].subSystemList.Append(sys).ToArray();
            UnityEngine.LowLevel.PlayerLoop.SetPlayerLoop(loop);
        }

        private void OnDestroy()
        {
            PlayerLoopSystem loop = UnityEngine.LowLevel.PlayerLoop.GetCurrentPlayerLoop();
            loop.subSystemList[PLAYER_LOOP_INDEX].subSystemList = loop.subSystemList[PLAYER_LOOP_INDEX].subSystemList
                .Where(x => x.type != GetType())
                .ToArray();
        }
    }
}