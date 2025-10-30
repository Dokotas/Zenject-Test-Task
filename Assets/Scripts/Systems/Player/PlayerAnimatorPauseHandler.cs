using GameCycle;

namespace Market
{
    public sealed class PlayerAnimatorPauseHandler : IGamePauseListener, IGameResumeListener
    {
        private readonly PlayerAnimator _playerAnimator;

        public PlayerAnimatorPauseHandler(PlayerAnimator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }

        public void OnPauseGame()
        {
            _playerAnimator.Idle();
        }

        public void OnResumeGame()
        {
        }
    }
}
