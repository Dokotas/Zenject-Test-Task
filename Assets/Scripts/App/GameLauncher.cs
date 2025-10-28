using GameCycle;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace App
{
    public sealed class GameLauncher
    {
        readonly GameStateManager _gameManager;

        public GameLauncher(GameStateManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Launch()
        {
            Debug.Log("Launch");
            _gameManager.StartGame();
            SceneManager.LoadScene("Game");
        }
    }
}



