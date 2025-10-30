using GameCycle;
using Zenject;
using App;

namespace Installers
{

    public sealed class ProjectInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<GameStateManager>().AsSingle();
            Container.Bind<ApplicationFinisher>().AsSingle();
        }
    }
}
