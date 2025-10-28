using System;

namespace PhotonTestTask
{
    public interface IActionable
    {
        event Action PickedUp;
        event Action Dropped;
        event Action Throwed;

        bool IsCarrying { get; }

        void Interract();
        void Throw();
    }
}
