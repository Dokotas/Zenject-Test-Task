using System.Collections.Generic;
using Zenject;

namespace GameCycle
{
    public sealed class GameKernel : MonoKernel,
        IGameStartListener,
        IGamePauseListener,
        IGameResumeListener,
        IGameEndListener
    {

        [Inject]
        private GameStateManager _gameManager;

        [Inject]
        private List<IGameListener> _listeners = new();

        [Inject(Optional =true, Source = InjectSources.Local)]
        private List<IGameTickable> _tickables = new();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private List<IGameFixedTickable> _fixedTickables = new();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private List<IGameLateTickable> _lateTickables = new();

        public override void Start()
        {
            base.Start();
            _gameManager.AddListener(this);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();


            _gameManager.RemoveListener(this);
        }

        public override void Update()
        {
            base.Update();
            if (_gameManager.State == GameState.RUN)
            {
                foreach (var tickable in _tickables)
                {
                    tickable.Tick();
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (_gameManager.State == GameState.RUN)
            {
                foreach (var tickable in _fixedTickables)
                {
                    tickable.FixedTick();
                }
            }
        }

        public override void LateUpdate()
        {
            base.LateUpdate();

            if (_gameManager.State == GameState.RUN)
            {
                foreach (var tickable in _lateTickables)
                {
                    tickable.LateTick();
                }
            }
        }

        public void OnStartGame()
        {
            foreach(var it in _listeners)
            {
                if(it is IGameStartListener listener)
                {
                    listener.OnStartGame();
                }
            }
        }

        public void OnPauseGame()
        {
            foreach (var it in _listeners)
            {
                if (it is IGamePauseListener listener)
                {
                    listener.OnPauseGame();
                }
            }
        }

        public void OnResumeGame()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameResumeListener listener)
                {
                    listener.OnResumeGame();
                }
            }
        }

        public void OnEndGame()
        {
            foreach (var it in _listeners)
            {
                if (it is IGameEndListener listener)
                {
                    listener.OnEndGame();
                }
            }
        }
    }
}
