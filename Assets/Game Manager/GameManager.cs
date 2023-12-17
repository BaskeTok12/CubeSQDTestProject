using System;
using System.Linq;
using Levels_Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game_Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager GameManagerInstance { get; private set; }
        
        public static event Action OnStart;
        public static event Action OnRestart;
        public static event Action OnFault;

        public static event Action OnFinish;

        [SerializeField] private LevelManager levelManager;
        
        private int _currentLevelNumber;
        
        private void Awake()
        {
            if (GameManagerInstance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            GameManagerInstance = this;
            //DontDestroyOnLoad(this);
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
            levelManager.RestartLevel();
            OnRestart?.Invoke();
        }

        public void NextLevel()
        {
            levelManager.ChangeToNextLevel();
        }

        public void OnPlayerFault()
        {
            OnFault?.Invoke();
        }
        
        public void OnPlayerFinished()
        {
            OnFinish?.Invoke();
        }
        
        private void SetResolutionAndFrameRate()
        {
            Resolution[] resolutions = Screen.resolutions;
            Application.targetFrameRate = (int)resolutions.Last().refreshRateRatio.value;
            QualitySettings.vSyncCount = 0;
        }
    }
}