using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Game_Manager;
using Player.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spline
{
   public class SplineFollowerController : MonoBehaviour
   {
      [SerializeField] private SplineFollower splineFollower;
      [field: SerializeField] public float MaxOffset { get; private set; }
      [SerializeField] private float swipeSpeed;
      
      private float _currentSpeed;

      public void StartFollowing()
      {
         splineFollower.follow = true;
      }
   
      public void StopFollowing()
      {
         splineFollower.follow = false;
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
         StartCoroutine(ChangeSpeedCoroutine(targetSpeed, duration));
      }
      
      private IEnumerator ChangeSpeedCoroutine(float targetSpeed, float duration)
      {
         float startTime = Time.time;
         float elapsedTime = 0f;

         while (elapsedTime < duration)
         {
            float t = elapsedTime / duration;
            splineFollower.followSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, t);
            
            elapsedTime = Time.time - startTime;
            yield return null;
         }

         // Убедитесь, что после завершения корутины скорость установлена в конечное значение
         splineFollower.followSpeed = targetSpeed;
      }
   }
}

