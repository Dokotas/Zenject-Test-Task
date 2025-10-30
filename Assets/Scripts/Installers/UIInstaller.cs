using Zenject;
using UI;
using UnityEngine;

namespace Installers
{
    public sealed class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIElements uiElements;

        public override void InstallBindings()
        {
            Container.Bind<UIElements>().FromInstance(uiElements).AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PausePanelHandler>().AsSingle()
                .WithArguments(uiElements.pausePanel)
                .NonLazy();

            BindButtons();
        }

        private void BindButtons()
        {
            Container.BindInterfacesAndSelfTo<PauseButton>().AsSingle()
                .WithArguments(uiElements.pauseButton)
                .NonLazy();
            Container.BindInterfacesAndSelfTo<ResumeButton>().AsSingle()
                .WithArguments(uiElements.resumeButton)
                .NonLazy();
            Container.BindInterfacesAndSelfTo<MenuButton>().AsSingle()
                .WithArguments(uiElements.menuButton)
                .NonLazy();
        }
    }
}
