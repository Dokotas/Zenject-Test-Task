using GameCycle;
using UnityEngine;

namespace UI
{
    public sealed class PausePanelHandler : IGamePauseListener, IGameResumeListener
    {
        private readonly GameObject _pausePanel;

        public PausePanelHandler(GameObject pausePanel)
        {
            _pausePanel = pausePanel;
        }

        public void OnPauseGame()
        {
            _pausePanel.SetActive(true);
        }

        public void OnResumeGame()
        {
            _pausePanel.SetActive(false);
        }
    }
}
