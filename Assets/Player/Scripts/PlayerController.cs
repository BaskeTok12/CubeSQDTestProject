using System;
using Game_Manager;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public static Action OnPlayerRunning;
        public bool IsPlayerRunning { get; private set; }
        public bool IsPlayerDancing { get; private set; }

        private void OnEnable()
        {
            GameManager.OnStart += SetPlayerRun;
        }

        private void OnDisable()
        {
            GameManager.OnStart -= SetPlayerRun;
        }

        private void SetPlayerRun()
        {
            IsPlayerRunning = true;
            OnPlayerRunning.Invoke();
        }
    }
}
