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
      
      private void OnEnable()
      {
         GameManager.OnStart += StartFollowing;
      }

      private void OnDisable()
      {
         GameManager.OnStart -= StartFollowing;
      }

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
   }
}

