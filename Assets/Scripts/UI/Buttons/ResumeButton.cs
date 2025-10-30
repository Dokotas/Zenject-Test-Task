using GameCycle;
using UnityEngine.UI;

namespace UI
{
    public sealed class ResumeButton : CustomButton
    {
        private readonly GameStateManager _gameStateManager;

        public ResumeButton(Button button, GameStateManager gameStateManager) : base(button)
        {
            _gameStateManager = gameStateManager;
        }

        protected override void OnButtonClicked()
        {
            _gameStateManager.ResumeGame();
        }
    }
}