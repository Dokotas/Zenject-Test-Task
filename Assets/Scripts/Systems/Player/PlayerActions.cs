using UnityEngine;
using System;

namespace PhotonTestTask
{
    public sealed class PlayerActions : IActionable
    {
        public bool IsCarrying { get => _goodsInHands != null; }

        public event Action PickedUp;
        public event Action Throwed;
        public event Action Dropped;

        private readonly Transform _hands, _body;
        private readonly TriggersCollection<Shelf> _availableShelfs;
        private readonly TriggersCollection<Goods> _availableGoods;
        private readonly float _dropForce, _throwForce;

        private Goods _goodsInHands;


        public PlayerActions(Transform hands, Transform body, PlayerConfig playerConfig,
            TriggersCollection<Shelf> availableShelfs, TriggersCollection<Goods> availableGoods)
        {
            _hands = hands;
            _body = body;
            _dropForce = playerConfig.dropForce;
            _throwForce = playerConfig.throwForce;
            _availableShelfs = availableShelfs;
            _availableGoods = availableGoods;
        }

        public void Interract()
        {
            if (_goodsInHands != null)
            {
                Drop();
            }
            else if (_availableGoods.ItemExist())
            {
                _goodsInHands = _availableGoods.ExtractItem();
                _goodsInHands.PickUp(_hands);
                PickedUp.Invoke();
            }
            else if (_availableShelfs.ItemExist())
            {
                _goodsInHands = _availableShelfs.GetItem().GetGoods();
                _goodsInHands.PickUp(_hands);
                PickedUp.Invoke();
            }
        }

        private void Drop()
        {
            _goodsInHands.Post(_body.forward * _dropForce);
            _goodsInHands = null;
            Dropped.Invoke();

        }

        public void Throw()
        {
            _goodsInHands.Post(_body.forward * _throwForce);
            _goodsInHands = null;
            Throwed.Invoke();
        }
    }
}