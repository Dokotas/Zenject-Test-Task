using System;

namespace PhotonTestTask
{
    public sealed class PlayerActionsHandler : IDisposable
    {
        private IInput _input;
        private IActionable _actionable;

        public PlayerActionsHandler(IInput input, IActionable actionable)
        {
            _input = input;
            _actionable = actionable;

            _input.Interract += _actionable.Interract;
            _input.Throw += _actionable.Throw;
        }

        public void Dispose()
        {
            _input.Interract -= _actionable.Interract;
            _input.Throw -= _actionable.Throw;
        }
    }
}