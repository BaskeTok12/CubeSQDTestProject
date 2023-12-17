using System;
using DG.Tweening;
using Game_Manager;
using Spline;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public static Action OnPlayerRunning;
        public static Action OnPlayerDancing;
        public static Action OnPlayerIdle;
        
        [Header("References")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private SplineFollowerController playerSplineFollower;
        [SerializeField] private PlayerCollisionController playerCollisionController;
        [Header("Movement Parameters")]
        [SerializeField] private float runSpeed;
        [SerializeField] private float speedChangingDuration;
        [SerializeField] private float toPlayerStopDuration;
        [Header("Player Death Scaling")]
        [SerializeField] private float finalDeathScale;
        [SerializeField] private float finalDeathDuration;
   
        private void Awake()
        {
            playerSplineFollower.SetSpeed(runSpeed, speedChangingDuration);
        }

        private void OnEnable()
        {
            GameManager.OnStart += SetPlayerRun;
            GameManager.OnFault += ScaleAndDestroyPlayer;
            GameManager.OnFinish += SetPlayerDancing;
        }

        private void OnDisable()
        {
            GameManager.OnStart -= SetPlayerRun;
            GameManager.OnFault -= ScaleAndDestroyPlayer;
            GameManager.OnFinish -= SetPlayerDancing;
        }

        private void ScaleAndDestroyPlayer()
        {
            if (gameObject == null) return;
          
            transform.DOScale(finalDeathScale, finalDeathDuration)
                .SetEase(Ease.InBounce)
                .OnComplete(() => Destroy(gameObject));
        }
        
        private void SetPlayerRun()
        {
            OnPlayerRunning?.Invoke();
            playerSplineFollower.SetSpeed(runSpeed, speedChangingDuration);
        }
        
        private void SetPlayerDancing()
        {
            OnPlayerDancing?.Invoke();
            playerSplineFollower.SetSpeed(0f, toPlayerStopDuration);
            playerCollisionController.enabled = false;
        }

        private void SetPlayerIdle()
        {
            OnPlayerIdle?.Invoke();    
            playerSplineFollower.SetSpeed(0f, 0.1f);
            playerCollisionController.enabled = false;
        }
    }
}
