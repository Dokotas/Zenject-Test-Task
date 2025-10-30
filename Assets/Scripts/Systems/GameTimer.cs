using UnityEngine;
using GameCycle;

namespace Market
{
    public sealed class GameTimer : IGameFixedTickable
    {
        private long _ticks;

        public void FixedTick()
        {
            _ticks++;
            Debug.Log(_ticks);
            //        int time = (int)(_ticks / Time.fixedDeltaTime);
            //        Debug.Log(time);
        }
    }
}
