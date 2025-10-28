using UnityEngine;

namespace PhotonTestTask
{
    public interface IMovable
    {
        float WalkSpeed { get; }
        float SprintSpeed { get; }

        bool IsWalking { get; }
        bool IsSprinting { get; }

        Rigidbody Rb { get; }
        Transform Transform { get; }

        void Move(Vector2 direction);
        void StartWalking();
        void StopWalking();
        void StartSprinting();
        void StopSprinting();
    }
}
