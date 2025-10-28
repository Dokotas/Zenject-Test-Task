using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public sealed class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] private Button startGameButton, exitGameButton;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<StartGameButton>().AsSingle().WithArguments(startGameButton).NonLazy();
            Container.BindInterfacesTo<ExitGameButton>().AsSingle().WithArguments(exitGameButton).NonLazy();
        }
    }
}
