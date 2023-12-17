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
            if (collision.gameObject.CompareTag(Tags.ObstacleTrigger))
            {
                TouchObstacle(collision.transform.position);
            }

            if (collision.gameObject.CompareTag(Tags.FinishTrigger))
            {
                _gameManager.OnPlayerFinished();
            }
        }
        private void TouchObstacle(Vector3 collisionPosition)
        {
            Instantiate(deathParticles, collisionPosition, quaternion.identity);
            _gameManager.OnPlayerFault();
        }
    }
}
