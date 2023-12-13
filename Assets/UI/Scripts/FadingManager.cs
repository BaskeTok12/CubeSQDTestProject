using DG.Tweening;
using UnityEngine;

namespace UI.Scripts
{
    public class FadingManager : MonoBehaviour
    {
        [Header("Main CanvasGroup")]
        [SerializeField] private CanvasGroup panelsCanvasGroup;

        private Tween _fadingTextTween;
        
        public void ShowPanel(GameObject panel, float duration)
        {
            panelsCanvasGroup.DOFade(1f, duration).OnComplete(() => ActivatePanel(panel));
        }
       
        public void HidePanel(GameObject panel, float duration)
        {
            panelsCanvasGroup.DOFade(0f, duration).OnComplete(() => DeactivatePanel(panel));
        }
        
        private void DeactivatePanel(GameObject panel)
        {
            panel.SetActive(false);
            _fadingTextTween.Pause();
        }
        
        private void ActivatePanel(GameObject panel)
        {
            panel.SetActive(true);
            _fadingTextTween.Play();
        }
    }
}