using System;
using Zenject;
using UnityEngine.UI;

namespace UI
{
    public abstract class CustomButton: IInitializable, IDisposable
    {
        private readonly Button _button;
        protected abstract void OnButtonClicked();

        public CustomButton(Button button)
        {
            _button = button;
        }

        public void Initialize()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void Dispose()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

    }
}
