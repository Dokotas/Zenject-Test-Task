using GameCycle;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public sealed class StartGameButton : CustomButton
    {
        private readonly GameStateManager _gameStateManager;

        public StartGameButton(Button button, GameStateManager gameStateManager) : base(button)
        {
            _gameStateManager = gameStateManager;
        }

        protected override void OnButtonClicked()
        {
            _gameStateManager.StartGame();

            SceneManager.LoadScene("Game");
        }
    }
}