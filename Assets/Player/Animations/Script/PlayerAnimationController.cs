using Game_Manager;
using Player.Scripts;
using UnityEngine;

namespace Player.Animations.Script
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsDancing = Animator.StringToHash("IsDancing");
        private static readonly int IsIdle = Animator.StringToHash("IsIdle");
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        { 
            PlayerController.OnPlayerRunning += UpdateRunTrigger;
            PlayerController.OnPlayerDancing += UpdateDanceTrigger;
            PlayerController.OnPlayerIdle += UpdateIdleTrigger;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerRunning -= UpdateRunTrigger;
            PlayerController.OnPlayerDancing -= UpdateDanceTrigger;
            PlayerController.OnPlayerIdle -= UpdateIdleTrigger;
        }

        private void UpdateRunTrigger()
        {
            _animator.SetBool(IsRunning, true);
        }
        
        private void UpdateDanceTrigger()
        {
            _animator.SetBool(IsDancing, true);
        }
        
        private void UpdateIdleTrigger()
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetBool(IsIdle, true);
        }
    }
}