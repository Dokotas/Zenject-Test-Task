using GameCycle;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(
        fileName = "ProjectlInstaller",
        menuName = "Installers/ProjectInstaller"
        )]
    public sealed class ProjectlInstaller : ScriptableObjectInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<GameStateManager>().AsSingle();
        }
    }
}
