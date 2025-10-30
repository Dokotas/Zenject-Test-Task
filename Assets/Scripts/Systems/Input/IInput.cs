using System;
using UnityEngine;

namespace Market
{
    public interface IInput
    {
        Vector2 MoveDirection { get; }

        event Action StartSprint, StopSprint, Interract, Throw;

    }
}
