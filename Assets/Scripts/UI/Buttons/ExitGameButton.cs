using GameCycle;
using UnityEngine.UI;
using App;

namespace UI
{
    public sealed class ExitGameButton : CustomButton
    {
        private readonly GameStateManager _gameStateManager;
        private readonly ApplicationFinisher _applicationFinisher;

        public ExitGameButton(Button button, ApplicationFinisher applicationFinisher) : base(button)
        {
            _applicationFinisher = applicationFinisher;
        }

        protected override void OnButtonClicked()
        {
            _applicationFinisher.Finish();
        }
    }
}
