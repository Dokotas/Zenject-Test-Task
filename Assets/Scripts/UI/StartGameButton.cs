using System;
using UnityEngine.UI;
using Zenject;
using App;

namespace UI
{
    public sealed class StartGameButton : IInitializable, IDisposable
    {
        private readonly Button _button;
        private readonly GameLauncher _gameLauncher;

        public StartGameButton(Button button, GameLauncher gameLauncher)
        {
            _button = button;
            _gameLauncher = gameLauncher;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void Dispose()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _gameLauncher.Launch();
        }
    }
}



