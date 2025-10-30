using GameCycle;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public sealed class MenuButton : CustomButton
    {
        private readonly GameStateManager _gameStateManager;

        public MenuButton(Button button, GameStateManager gameStateManager) : base(button)
        {
            _gameStateManager = gameStateManager;
        }

        protected override void OnButtonClicked()
        {
            _gameStateManager.ResumeGame();

            SceneManager.LoadScene("Menu");
        }
    }
}