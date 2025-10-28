using PhotonTestTask;
using Zenject;

namespace Installers
{
    public sealed class SignalsInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<TriggerEnteredSignal<Shelf>>();
            Container.DeclareSignal<TriggerExitedSignal<Shelf>>();
            Container.Bind<CustomTriggerHandler<Shelf>>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Shelf>().FromComponentsInHierarchy().AsCached();
            

            Container.DeclareSignal<TriggerEnteredSignal<Goods>>();
            Container.DeclareSignal<TriggerExitedSignal<Goods>>();
            Container.Bind<CustomTriggerHandler<Goods>>().AsSingle().NonLazy();

        }
    }
}
