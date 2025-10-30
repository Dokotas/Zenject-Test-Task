using System.Collections.Generic;

namespace GameCycle
{
    public sealed class GameStateManager
    {

        public GameState State { get; private set; }// = GameState.RUN;

        private readonly List<IGameListener> _listeners = new();

        public void AddListener(IGameListener listener)
        {
            _listeners.Add(listener); 
        }

        public void RemoveListener(IGameListener listener)
        {
            _listeners.Remove(listener);
        }

        public void StartGame()
        {
            if (State != GameState.OFF)
            {
                return;
            }

            foreach (var it in _listeners)
            {
                if (it is IGameStartListener listener)
                {
                    listener.OnStartGame();
                }
            }

            State = GameState.RUN;
        }

        public void PauseGame()
        {
            if (State != GameState.RUN)
            {
                return;
            }

            foreach (var it in _listeners)
            {
                if (it is IGamePauseListener listener)
                {
                    listener.OnPauseGame();
                }
            }

            State = GameState.PAUSE;
        }

        public void ResumeGame()
        {
            if (State != GameState.PAUSE)
            {
                return;
            }

            foreach (var it in _listeners)
            {
                if (it is IGameResumeListener listener)
                {
                    listener.OnResumeGame();
                }
            }

            State = GameState.RUN;
        }

        public void EndGame()
        {
            if (State != GameState.RUN)
            {
                return;
            }

            foreach (var it in _listeners)
            {
                if (it is IGameEndListener listener)
                {
                    listener.OnEndGame();
                }
            }

            State = GameState.END;
        }
    }
}
