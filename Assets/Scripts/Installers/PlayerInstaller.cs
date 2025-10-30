using UnityEngine;
using Zenject;
using Market;

namespace Installers
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Keymap keymap;
        [SerializeField] private PlayerConfig playerConfig;

        public override void InstallBindings()
        {
            BindPlayer();
            BindInputService();
        }

        private void BindPlayer()
        {
            GameObject playerGO = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            Rigidbody playerRb = playerGO.GetComponent<Rigidbody>();
            Transform playerTransform = playerGO.transform;
            Animator playerAnimator = playerGO.GetComponent<Animator>();
            PlayerHands playerHands = playerGO.GetComponent<PlayerHands>();

            Container.Bind<IMovable>().To<PlayerMovement>().AsSingle().WithArguments(playerConfig, playerRb, playerTransform);

            Container.BindInterfacesAndSelfTo<PlayerAnimation>().AsSingle().WithArguments(playerAnimator).NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerActions>().AsSingle().WithArguments(playerHands.HandsWithItem, playerTransform, playerConfig).NonLazy();
        }

        private void BindInputService()
        {
            Container.Bind<Keymap>().FromInstance(keymap).AsSingle();
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();

            Container.BindInterfacesAndSelfTo<TriggersCollection<Shelf>>().AsSingle();
            Container.BindInterfacesAndSelfTo<TriggersCollection<Goods>>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerMovementHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerActionsHandler>().AsSingle().NonLazy();
        }
    }
}
