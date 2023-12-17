using System;
using System.Collections;
using Dreamteck.Splines;
using UnityEngine;

namespace Spline
{
    public class SplineFollowerController : MonoBehaviour
    {
        [Header("Main Follower")]
        [SerializeField] private SplineFollower splineFollower;
        [Header("Swipe (X-Offset) values")]
        [SerializeField] private float swipeSpeed;
        [field: SerializeField] public float MaxOffset { get; private set; }
        
        private float _currentSpeed;

        protected void StartFollowing()
        {
            splineFollower.follow = true;
        }

        public void SetPlayerOffsetX(float velocity)
        {
            var offsetX = Mathf.Clamp(splineFollower.motion.offset.x + velocity * swipeSpeed, -MaxOffset,
                MaxOffset);

            splineFollower.motion.offset =
                new Vector2(offsetX, splineFollower.motion.offset.y);
        }

        public void SetSpeed(float targetSpeed, float duration)
        {
            if (splineFollower == null) throw new NullReferenceException();
            
            StartCoroutine(ChangeSpeedCoroutine(targetSpeed, duration));
        }

        private IEnumerator ChangeSpeedCoroutine(float targetSpeed, float duration)
        {
            var startTime = Time.time;
            var startSpeed = _currentSpeed;

            while (Time.time - startTime < duration)
            {
                var time = (Time.time - startTime) / duration;
                _currentSpeed = Mathf.Lerp(startSpeed, targetSpeed, time);

                SetFollowerSpeed(_currentSpeed);

                yield return null;
            }

            _currentSpeed = targetSpeed;

            SetFollowerSpeed(_currentSpeed);
        }

        private void SetFollowerSpeed(float value)
        {
            splineFollower.followSpeed = value;
        }
    }
}