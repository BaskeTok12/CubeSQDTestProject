using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Player.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class SplineFollowerController  : MonoBehaviour
{
   [SerializeField] private SplineFollower playerSplineFollower;
   [SerializeField] private InputController inputController;
   [field: SerializeField] public float MaxOffset { get; private set; }

   private void Update()
   {
      SetPlayerOffsetX(inputController.GetInputXValue());
   }

   public void StartFollowing()
   {
      playerSplineFollower.follow = true;
   }
   
   public void StopFollowing()
   {
      playerSplineFollower.follow = false;
   }

   public void SetPlayerOffsetX(float velocity)
   {
      var offsetX = Mathf.Clamp(playerSplineFollower.motion.offset.x * velocity * Time.deltaTime, -MaxOffset,
         MaxOffset);
      Debug.Log("Offset:"+ offsetX);
      playerSplineFollower.motion.offset =
         new Vector2(offsetX, playerSplineFollower.motion.offset.y);
   }
}

