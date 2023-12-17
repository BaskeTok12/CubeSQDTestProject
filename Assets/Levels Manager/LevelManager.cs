using System;
using UnityEngine;

namespace Levels_Manager
{
    public class LevelManager : MonoBehaviour
    {
        public static Action<int> OnLevelChanged;
        
        [Header("Level Prefabs")]
        [SerializeField] private GameObject[] levels;
        [Header("Levels Parent Transform")]
        [SerializeField] private Transform levelsParent;
        public int CurrentLevelNumber { get; private set; }
        
        private GameObject _currentLevelInstance;

        private void Awake()
        {
            CurrentLevelNumber = 0;
            InstantiateCurrentLevel();
        }

        public void RestartLevel()
        {
            Destroy(_currentLevelInstance);
            InstantiateCurrentLevel();
        }

        public void ChangeToNextLevel()
        {
            Destroy(_currentLevelInstance);

            CurrentLevelNumber = (CurrentLevelNumber + 1) % levels.Length;

            InstantiateCurrentLevel();
        }

        private void InstantiateCurrentLevel()
        {
            _currentLevelInstance = Instantiate(levels[CurrentLevelNumber], levelsParent.position, Quaternion.identity, levelsParent);
            _currentLevelInstance.SetActive(true);
            OnLevelChanged?.Invoke(CurrentLevelNumber + 1);
        }
    }

}