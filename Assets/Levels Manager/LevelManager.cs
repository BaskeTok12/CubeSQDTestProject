using UnityEngine;

namespace Levels_Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;
        [SerializeField] private Transform levelsParent;
        private GameObject _currentLevelInstance;
        public int CurrentLevelNumber { get; private set; }

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

            // Проверка на выход за границы массива levels
            CurrentLevelNumber = (CurrentLevelNumber + 1) % levels.Length;

            InstantiateCurrentLevel();
        }

        private void InstantiateCurrentLevel()
        {
            _currentLevelInstance = Instantiate(levels[CurrentLevelNumber], levelsParent.position, Quaternion.identity, levelsParent);
            _currentLevelInstance.SetActive(true);
        }
    }

}