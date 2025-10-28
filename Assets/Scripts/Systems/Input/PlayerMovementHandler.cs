using GameCycle;
using System;
using Zenject;

namespace PhotonTestTask
{
    public sealed class PlayerMovementHandler : IInitializable, IDisposable, IGameFixedTickable
    {
        private readonly IInput _input;
        private readonly IMovable _movable;
        private readonly IActionable _actionable;

        public PlayerMovementHandler(IInput input, IMovable movable, IActionable actionable)
        {
            _input = input;
            _movable = movable;
            _actionable = actionable;
        }

        public void Initialize()
        {
            _input.StartSprint += StartSprinting;
            _input.StopSprint += _movable.StopSprinting;
        }

        private void StartSprinting()
        {
            if(!_actionable.IsCarrying)
            {
                _movable.StartSprinting();
            }
        }

        public void FixedTick()
        {
            if (_input.MoveDirection.magnitude > 0)
            {
                _movable.StartWalking();
                _movable.Move(_input.MoveDirection.normalized);
            }
            else
            {
                _movable.StopWalking();
            }

            if (_actionable.IsCarrying)
            {
                _movable.StopSprinting();
            }
        }

        public void Dispose()
        {
            _input.StartSprint -= _movable.StartSprinting;
            _input.StopSprint -= _movable.StopSprinting;
        }

    }
}