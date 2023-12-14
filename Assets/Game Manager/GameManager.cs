using System;
using System.Linq;
using UnityEngine;

namespace Game_Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager GameManagerInstance { get; private set; }
        
        public static event Action OnStart;
        public static event Action OnRestart;
        public static event Action OnFault;
        
        private int _currentLevelNumber;
        
        private void Awake()
        {
            if (GameManagerInstance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            GameManagerInstance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            SetResolutionAndFrameRate();
        }

        public void StartGame()
        {
            OnStart?.Invoke();
            Debug.Log("Game Started!");
        }

        public void RestartGame()
        {
            OnRestart?.Invoke();
        }

        public void OnPlayerFault()
        {
            OnFault?.Invoke();
        }
        
        private void SetResolutionAndFrameRate()
        {
            Resolution[] resolutions = Screen.resolutions;
            Application.targetFrameRate = (int)resolutions.Last().refreshRateRatio.value;
            QualitySettings.vSyncCount = 0;
        }
    }
}