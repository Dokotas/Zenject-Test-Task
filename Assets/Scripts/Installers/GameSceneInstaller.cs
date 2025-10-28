using Zenject;
using PhotonTestTask;
using UnityEngine;

namespace Installers
{
    public sealed class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private UIElements uiPrefab;

        public override void InstallBindings()
        {
            Container.Bind<CashRegister>().FromComponentsInHierarchy().AsCached();
            Container.Bind<UIElements>().FromComponentInNewPrefab(uiPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle().NonLazy();
        }
    }
}
