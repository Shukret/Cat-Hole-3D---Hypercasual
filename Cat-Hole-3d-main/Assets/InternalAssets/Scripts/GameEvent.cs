using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameEvent : MonoBehaviour
    {
        public UnityEvent onChange;
        public GameState targetState;
        private void OnEnable()
        {
            GameEvents.onGameStateChange += GameEventsOnGameStateChange;
        }
        
        private void OnDisable()
        {
            GameEvents.onGameStateChange -= GameEventsOnGameStateChange;
        }

        private void GameEventsOnGameStateChange(GameState state)
        {
            if (state == targetState)
            {
                onChange?.Invoke();
            }
        }
    }
}