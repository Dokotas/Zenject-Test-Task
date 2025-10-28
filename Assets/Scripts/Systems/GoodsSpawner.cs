using UnityEngine;
using Zenject;

namespace PhotonTestTask
{
    public sealed class GoodsSpawner
    {
        [Inject(Id = "Bag")]
        private readonly Goods.Pool _bagPool;
        [Inject(Id = "Bottle")]
        private readonly Goods.Pool _bottlePool;
        [Inject(Id = "Box")]
        private readonly Goods.Pool _boxPool;

        [Inject(Id = "Bag")]
        private readonly Transform _bagPoolParentContainer;
        [Inject(Id = "Bottle")]
        private readonly Transform _bottlePoolParentContainer;
        [Inject(Id = "Box")]
        private readonly Transform _boxPoolParentContainer;

        public Goods Spawn(GoodsType goodsType)
        {
            Goods result;

            switch (goodsType){
                case GoodsType.Bag:
                    result = _bagPool.Spawn();
                    result.ParentContainer = _bagPoolParentContainer;
                    break;
                case GoodsType.Bottle:
                    result = _bottlePool.Spawn();
                    result.ParentContainer = _bottlePoolParentContainer;
                    break;
                case GoodsType.Box:
                    result = _boxPool.Spawn();
                    result.ParentContainer = _boxPoolParentContainer;
                    break;
                default:
                    Debug.LogError("There are no such goods type to spawn");
                    result = null;
                    break;
            }

            result.Type = goodsType;
            return result;
        }

        public void DeSpawn(GoodsType goodsType, Goods goods)
        {
            switch (goodsType)
            {
                case GoodsType.Bag:
                    _bagPool.Despawn(goods);
                    break;
                case GoodsType.Bottle:
                    _bottlePool.Despawn(goods);
                    break;
                case GoodsType.Box:
                    _boxPool.Despawn(goods);
                    break;
                default:
                    Debug.LogError("There are no such goods type to despawn");
                    break;
            }
        }
    }
}
