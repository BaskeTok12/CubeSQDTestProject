using Spline;
using UnityEngine;

namespace Player.Scripts
{
    public class InputController : MonoBehaviour
    {
        [Header("Player Spline")]
        [SerializeField] private SplineFollowerController playerSplineController;

        private Vector2 _touchStartPos;
        
        private float _lastSwipeValue;

        private void Update()
        {
            if (Input.touchCount <= 0) return;

            UpdateSwipeValue();
            playerSplineController.SetPlayerOffsetX(_lastSwipeValue);
        }

        private void UpdateSwipeValue()
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _touchStartPos = touch.position;
            }
            
            var deviation = (touch.position.x - _touchStartPos.x) / (Screen.width / 2f);
            
            _lastSwipeValue = Mathf.Clamp(deviation, -1f, 1f);
        }
    }

}