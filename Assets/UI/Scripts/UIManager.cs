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
        [SerializeField] private GameObject faultPanel;
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
            //DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            GameManager.OnFault += ShowFaultPanel;
            GameManager.OnFinish += ShowFinalPanel;
        }

        private void OnDisable()
        {
            GameManager.OnFault -= ShowFaultPanel;
            GameManager.OnFinish -= ShowFinalPanel;
        }

        private void Start()
        {
            _gameManager = GameManager.GameManagerInstance;
        }

        public void StartGame()
        {
            StartCoroutine(FadeOutToPlaymode());
        }
        
        public void RestartGame()
        {
            StartCoroutine(FadeOutFromRestartToPlaymode());
        }

        public void NextLevel()
        {
            StartCoroutine(FadeFromFinalPanelToStart());
        }

        private void ShowFaultPanel()
        {
            fadingManager.ShowPanel(faultPanel, tweenDuration);
            //StartCoroutine(FadeInToFaultPanel());
        }
        
        private void ShowFinalPanel()
        {
            fadingManager.ShowPanel(finalGamePanel, tweenDuration);
            //StartCoroutine(FadeInToFaultPanel());
        }
        
        private void HideFinalPanel()
        {
            fadingManager.HidePanel(finalGamePanel, tweenDuration);
            //StartCoroutine(FadeInToFaultPanel());
        }
        
        private IEnumerator FadeOutToPlaymode()
        {
            fadingManager.HidePanel(startGamePanel, tweenDuration);
            _gameManager.StartGame();
            
            yield return null;
        }
        
        private IEnumerator FadeOutFromRestartToPlaymode()
        {
            fadingManager.HidePanel(faultPanel, restartLatency);

            yield return new WaitForSeconds(restartLatency);
            _gameManager.RestartGame();

            fadingManager.ShowPanel(startGamePanel, tweenDuration);
        }
        
        private IEnumerator FadeFromFinalPanelToStart()
        {
            fadingManager.HidePanel(finalGamePanel, restartLatency);

            yield return new WaitForSeconds(restartLatency);
            _gameManager.NextLevel();
            
            fadingManager.ShowPanel(startGamePanel, tweenDuration);
        }
        
        /*private IEnumerator FadeInToFaultPanel()
        {
            fadingManager.ShowPanel(faultPanel, tweenDuration);
            yield return null;
        }*/
        
        /*private IEnumerator FadeInToFinalPanel()
        {
            fadingManager.ShowPanel(finalGamePanel, tweenDuration);
            yield return null;
        }*/
    }
}