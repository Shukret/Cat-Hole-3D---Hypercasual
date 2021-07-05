using UnityEngine;

namespace Game
{
    public static class GameEvents
    {
        public delegate void OnGameStateChange(GameState state);
        public static event OnGameStateChange onGameStateChange;

        private static GameState gameState;
        
        public static void ChangeGameState(GameState state)
        {
            if (state == GameState.Finish && gameState == GameState.Fail)
            {
                return;
            }

            if (state == gameState && gameState != GameState.Start)
            {
                return;
            }
            
            
            gameState = state;
            onGameStateChange?.Invoke(state);
        }
    }
}