using System;
using UnityEngine.UI;
using Zenject;
using App;

namespace UI
{
    public sealed class ExitGameButton : IInitializable, IDisposable
    {
        private readonly Button _button;
        private readonly ApplicationFinisher _applicationFinisher;

        public ExitGameButton(Button button, ApplicationFinisher applicationFinisher)
        {
            _button = button;
            _applicationFinisher = applicationFinisher;
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
            _applicationFinisher.Finish();
        }
    }
}



