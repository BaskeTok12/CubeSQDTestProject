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
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        { 
            PlayerController.OnPlayerRunning += UpdateRunTrigger;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerRunning -= UpdateRunTrigger;
        }

        private void UpdateRunTrigger()
        {
            _animator.SetBool(IsRunning, true);
        }
        
        private void UpdateDanceTrigger()
        {
            _animator.SetBool(IsDancing, true);
        }
    }
}