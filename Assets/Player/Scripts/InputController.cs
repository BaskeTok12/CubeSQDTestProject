using System;
using Spline;
using UnityEngine;
using UnityEngine.XR;

namespace Player.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private SplineFollowerController playerSplineController;

        private Vector2 _touchStartPos;
        private float _lastSwipeValue;

        private void Update()
        {
            if (Input.touchCount <= 0) return;
            
            playerSplineController.SetPlayerOffsetX(GetInputXValue());
        }

        public float GetInputXValue()
        {
            var touch = Input.GetTouch(0);
            var fingerPositionX = (touch.position.x - Screen.width / 2f) / (Screen.width / 2f);
            
            var normalizedFingerPositionX = Mathf.Clamp(fingerPositionX, -1f, 1f);
            _lastSwipeValue = normalizedFingerPositionX;
            
            return _lastSwipeValue;
        }
    }
}