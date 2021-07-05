using System;
using BayatGames.SaveGameFree;
using MoreMountains.Feedbacks;
using UnityEngine;
using GameAnalyticsSDK;

namespace Game
{
    public class LevelController : MonoBehaviour
    {
        public LevelContainer levelContainer;
        public Transform levelParent;

        public delegate void OnLevelLoad(Level level);

        public static event OnLevelLoad onLevelLoad;
        
        public static Level CurrentLevel { get; private set; }
        public static string LevelName { get; private set; }

        private static LevelController Instance;
        public static int currentLevelIndex = 0;
        
        [MMFInspectorButton("TestButtonToLoadLevel")]
        /// a test button for the inspector
        public bool TestButton;
        public int testLevelIndex;
        
        const string saveKey = "level";

        private void Awake()
        {
            Instance = this;
            
            GameEvents.onGameStateChange += GameEventsOnGameStateChange;
        }

        private void OnDestroy()
        {
            GameEvents.onGameStateChange -= GameEventsOnGameStateChange;
        }

        private void GameEventsOnGameStateChange(GameState state)
        {
            if (state == GameState.Finish)
            {
                OpenNextLevel();
            }
        }
        
        private void Start()
        {
            if (SaveGame.Exists(saveKey))
            {
                currentLevelIndex = SaveGame.Load<int>(saveKey, SaveGamePath.PersistentDataPath);
            }

            var index = currentLevelIndex;

            if (index < 0)
            {
                index = 0;
            }

            if (index > levelContainer.Levels.Length - 1)
            {
                index = 0;
            }
            
            Load(index);
        }

        private void Load(int index)
        {
            if (CurrentLevel)
            {
                Destroy(CurrentLevel.gameObject);
            }

            CurrentLevel = Instantiate(levelContainer.Levels[index], levelParent);

            LevelName = levelContainer.Levels[index].name;
            
            onLevelLoad?.Invoke(CurrentLevel);
        }

        private static void OpenNextLevel()
        {
            var index = currentLevelIndex + 1;
            
            if (index < 0)
            {
                index = 0;
            }

            if (index > Instance.levelContainer.Levels.Length - 1)
            {
                index = 0;
            }
            
            SaveGame.Save<int>(saveKey, index, SaveGamePath.PersistentDataPath);
        }

        public void TestButtonToLoadLevel()
        {
            Load(testLevelIndex);
            SaveGame.Save<int>(saveKey, testLevelIndex, SaveGamePath.PersistentDataPath);
        }
    }
}