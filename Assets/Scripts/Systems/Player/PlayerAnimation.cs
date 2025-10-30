using GameCycle;
using System;
using UnityEngine;
using Zenject;

namespace Market
{
    public class PlayerAnimation : IGameFixedTickable, IInitializable, IDisposable
    {
        private Animator _animator;
        private IMovable _movable;
        private IActionable _actionable;

        private int _isWalkingHash, _isSprintingHash, _pickedUpHash, _droppedHash, _throwedHash;

        public PlayerAnimation(Animator animator, IMovable movable, IActionable actionable)
        {
            _animator = animator;
            _movable = movable;
            _actionable = actionable;
        }
        public void Initialize()
        {
            SetHashs();
            _actionable.PickedUp += OnPickedUp;
            _actionable.Dropped += OnDropped;
            _actionable.Throwed += OnThrowed;
        }

        private void OnDropped()
        {
            _animator.SetTrigger(_droppedHash);
        }

        private void OnThrowed()
        {
            _animator.SetTrigger(_throwedHash);
        }

        private void OnPickedUp()
        {
            _animator.SetTrigger(_pickedUpHash);
        }

        private void SetHashs()
        {
            _isWalkingHash = Animator.StringToHash("Is walking");
            _isSprintingHash = Animator.StringToHash("Is sprinting");
            _pickedUpHash = Animator.StringToHash("Picked up");
            _droppedHash = Animator.StringToHash("Dropped");
            _throwedHash = Animator.StringToHash("Throwed");
        }

        public void FixedTick()
        {
            _animator.SetBool(_isWalkingHash, _movable.IsWalking);
            _animator.SetBool(_isSprintingHash, _movable.IsSprinting);
        }

        public void Dispose()
        {
            _actionable.PickedUp -= OnPickedUp;
            _actionable.Dropped -= OnDropped;
            _actionable.Throwed -= OnThrowed;
        }
    }
}