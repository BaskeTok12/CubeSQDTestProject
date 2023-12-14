using System;
using UnityEngine;

namespace Level_Controller
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;
        
        public int CurrentLevelNumber { get; private set; }
        
        private void Awake()
        {
            CurrentLevelNumber = 0;
        }

        public void ChangeLevel(int number)
        {
            levels[CurrentLevelNumber].SetActive(false);
            levels[number].SetActive(true);
            
            CurrentLevelNumber = number;
        }

        public void ChangeToNextLevel()
        {
            levels[CurrentLevelNumber].SetActive(false);

            if (CurrentLevelNumber >= levels.Length)
            {
                CurrentLevelNumber = 0;
            }
            else
            {
                CurrentLevelNumber++;
            }
            
            levels[CurrentLevelNumber].SetActive(true);
        }
        
        
    }
}