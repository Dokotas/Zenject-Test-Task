using System;
using UnityEngine;
using Zenject;

namespace PhotonTestTask
{
    public class CashRegister : MonoBehaviour
    {
        public Action<GoodsType> GoodsPurchased;

        private GoodsSpawner _goodsSpawner;

        [Inject]
        public void Construct(GoodsSpawner goodsSpawner)
        {
            _goodsSpawner = goodsSpawner;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Goods>(out var goods))
            {
                if (goods.IsPickedUp)
                    return;

                GoodsPurchased.Invoke(goods.Type);
                _goodsSpawner.DeSpawn(goods.Type, goods);
            }
        }
    }
}
