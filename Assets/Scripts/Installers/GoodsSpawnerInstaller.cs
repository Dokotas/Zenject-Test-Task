using PhotonTestTask;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class GoodsSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Goods bag, bottle, box;
        [SerializeField] private Transform bagParentContainer, bottleParentContainer, boxParentContainer;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Goods, Goods.Pool>()
            .WithId("Bag")
            .WithInitialSize(5)
            .FromComponentInNewPrefab(bag)
            .UnderTransform(bagParentContainer);

            Container.BindMemoryPool<Goods, Goods.Pool>()
            .WithId("Bottle")
            .WithInitialSize(5)
            .FromComponentInNewPrefab(bottle)
            .UnderTransform(bottleParentContainer);

            Container.BindMemoryPool<Goods, Goods.Pool>()
            .WithId("Box")
            .WithInitialSize(5)
            .FromComponentInNewPrefab(box)
            .UnderTransform(boxParentContainer);

            Container.Bind<Transform>()
                .WithId("Bag")
                .FromInstance(bagParentContainer)
                .AsCached();

            Container.Bind<Transform>()
                .WithId("Bottle")
                .FromInstance(bottleParentContainer)
                .AsCached();

            Container.Bind<Transform>()
            .WithId("Box")
            .FromInstance(boxParentContainer)
            .AsCached();

            Container.Bind<GoodsSpawner>().AsSingle();
        }
    }
}
