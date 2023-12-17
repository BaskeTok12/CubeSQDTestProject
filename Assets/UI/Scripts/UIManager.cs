using System.Collections;
using Game_Manager;
using Levels_Manager;
using TMPro;
using UnityEngine;

namespace UI.Scripts
{
    public class UIManager : MonoBehaviour
    {
        private GameManager _gameManager;
        
        [Header("Panels")] 
        [SerializeField] private GameObject startGamePanel;
        [SerializeField] private GameObject faultPanel;
        [SerializeField] private GameObject finalGamePanel;
        [Header("TweenParameters")]
        [SerializeField] private FadingManager fadingManager;
        [SerializeField] private float tweenDuration;
        [SerializeField] private float restartLatency;
        [Header("DevLogs")] 
        [SerializeField] private TextMeshProUGUI currentLevelNumberText;
        
        private void OnEnable()
        {
            GameManager.OnFault += ShowFaultPanel;
            GameManager.OnFinish += ShowFinalPanel;

            LevelManager.OnLevelChanged += UpdateCurrentNumberText;
        }

        private void OnDisable()
        {
            GameManager.OnFault -= ShowFaultPanel;
            GameManager.OnFinish -= ShowFinalPanel;
            
            LevelManager.OnLevelChanged -= UpdateCurrentNumberText;
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
        }
        
        private void ShowFinalPanel()
        {
            fadingManager.ShowPanel(finalGamePanel, tweenDuration);
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

        private void UpdateCurrentNumberText(int levelNumber)
        {
            currentLevelNumberText.text = levelNumber.ToString();
        }
    }
}