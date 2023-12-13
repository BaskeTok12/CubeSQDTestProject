using UnityEngine;
using UnityEngine.XR;

namespace Player.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private SplineFollowerController playerSplineController;

        private Vector2 _touchStartPos;
        private float _lastSwipeValue;

        public float GetInputXValue()
        {
            if (Input.touchCount <= 0) return _lastSwipeValue;
            
            Touch touch = Input.GetTouch(0);
            float fingerPositionX = (touch.position.x - Screen.width / 2f) / (Screen.width / 2f);
            
            float normalizedFingerPositionX = Mathf.Clamp(fingerPositionX, -1f, 1f);
            _lastSwipeValue = normalizedFingerPositionX;
            //Debug.Log("Normalized Finger Position X: " + normalizedFingerPositionX);
            return _lastSwipeValue;
        }
    }
}