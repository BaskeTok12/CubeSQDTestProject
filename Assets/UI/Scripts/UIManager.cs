using System;
using System.Collections;
using Game_Manager;
using UnityEngine;

namespace UI.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager UIManagerInstance { get; private set; }

        private GameManager _gameManager;
        
        [Header("Panels")] 
        [SerializeField] private GameObject startGamePanel;
        [SerializeField] private GameObject finalGamePanel;
        [Header("TweenParameters")]
        [SerializeField] private FadingManager fadingManager;
        [SerializeField] private float tweenDuration;
        [SerializeField] private float restartLatency;
        
        private void Awake()
        {
            if (UIManagerInstance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            UIManagerInstance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _gameManager = GameManager.GameManagerInstance;
        }

        public void StartGame()
        {
            StartCoroutine(FadeToPlaymode());
        }
        
        private IEnumerator FadeToPlaymode()
        {
            fadingManager.HidePanel(startGamePanel, tweenDuration);
            _gameManager.StartGame();
            
            yield return null;
        }
        
        private IEnumerator FadeToRestart()
        {
            fadingManager.HidePanel(finalGamePanel, restartLatency);

            yield return new WaitForSeconds(restartLatency);
            
            _gameManager.RestartGame();
        }
    }
}