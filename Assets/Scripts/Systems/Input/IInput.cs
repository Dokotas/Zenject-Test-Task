using System;
using UnityEngine;

namespace PhotonTestTask
{
    public interface IInput
    {
        Vector2 MoveDirection { get; }

        event Action StartSprint, StopSprint, Interract, Throw;

    }
}
