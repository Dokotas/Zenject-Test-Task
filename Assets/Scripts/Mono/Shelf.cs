using UnityEngine;
using Zenject;

namespace Market
{
    public class Shelf : MonoBehaviour, ITriggerable<Shelf>
    {
        [SerializeField] private GoodsType goodsType;

        private GoodsSpawner _goodsSpawner;

        public Shelf Component => this;

        public CustomTrigger CustomTrigger { get; set; }

        private void Start()
        {
            //gameObject.AddComponent<CustomTrigger>();
        }

        [Inject]
        public void Construct(GoodsSpawner goodsSpawner)
        {
            _goodsSpawner = goodsSpawner;
        }

        public Goods GetGoods()
        {
            return _goodsSpawner.Spawn(goodsType);
        }

    }
}
