using GameCycle;
using UnityEngine.UI;

namespace UI
{
    public sealed class PauseButton : CustomButton
    {
        private readonly GameStateManager _gameStateManager;

        public PauseButton(GameStateManager gameStateManager, Button button) : base(button)
        {
            _gameStateManager = gameStateManager;
        }

        protected override void OnButtonClicked()
        {
            _gameStateManager.PauseGame();
        }
    }
}