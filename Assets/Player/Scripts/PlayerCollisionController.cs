using System;
using Common.CommonScripts.Constants;
using Game_Manager;
using Unity.Mathematics;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerCollisionController : MonoBehaviour
    {
        [Header("Obstacle touch effect")]
        [SerializeField] private ParticleSystem deathParticles;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.GameManagerInstance;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("OnCollisionEnter");
            if (collision.gameObject.CompareTag(Tags.ObstacleTrigger))
            {
                TouchObstacle(collision.transform.position);
            }
        }
        private void TouchObstacle(Vector3 collisionPosition)
        {
            Instantiate(deathParticles, collisionPosition, quaternion.identity);
            _gameManager.OnPlayerFault();
        }
    }
}
