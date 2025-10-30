using UnityEngine;

namespace Market
{
    public sealed class PlayerMovement : IMovable
    {
        public float WalkSpeed { get; private set; }
        public float SprintSpeed { get; private set; }
        public float RotationSpeed { get; private set; }

        public bool IsSprinting { get; private set; }
        public bool IsWalking { get; private set; }


        public Rigidbody Rb { get; private set; }
        public Transform Transform { get; private set; }


        public PlayerMovement(PlayerConfig playerConfig, Rigidbody rb, Transform transform)
        {
            WalkSpeed = playerConfig.walkSpeed;
            SprintSpeed = playerConfig.sprintSpeed;
            RotationSpeed = playerConfig.rotationSpeed;
            Rb = rb;
            Transform = transform;
        }

        public void Move(Vector2 direction)
        {
            Rb.linearVelocity = new Vector3(direction.x, Rb.linearVelocity.y, direction.y) * (IsSprinting ? SprintSpeed : WalkSpeed);

            var targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));

            // Calculate rotation difference
            Quaternion rotationDifference = targetRotation * Quaternion.Inverse(Rb.rotation);

            // Convert to angle-axis representation
            rotationDifference.ToAngleAxis(out float angle, out Vector3 axis);

            // Normalize angle to shortest path
            if (angle > 180f)
            {
                angle -= 360f;
            }

            // Convert angle to radians and apply rotation speed
            float angularSpeed = angle * Mathf.Deg2Rad * RotationSpeed;

            // Set angular velocity
            Rb.angularVelocity = axis * angularSpeed;
        }

        public void StartWalking()
        {
            IsWalking = true;
        }

        public void StopWalking()
        {
            IsWalking = false;
            Rb.angularVelocity = Vector3.zero;
        }

        public void StartSprinting()
        {
            IsSprinting = true;
        }

        public void StopSprinting()
        {
            IsSprinting = false;
        }
    }
}