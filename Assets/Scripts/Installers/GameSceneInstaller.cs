using Zenject;
using Market;
using UnityEngine;

namespace Installers
{
    public sealed class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CashRegister>().FromComponentsInHierarchy().AsCached();
        }
    }
}
