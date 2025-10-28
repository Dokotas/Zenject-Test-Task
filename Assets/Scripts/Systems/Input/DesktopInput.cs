using GameCycle;
using System;
using UnityEngine;

namespace PhotonTestTask
{
    public sealed class DesktopInput : IInput, IGameTickable
    {
        public Vector2 MoveDirection { get; private set; }

        public event Action StartSprint;
        public event Action StopSprint;
        public event Action Interract;
        public event Action Throw;

        readonly Keymap keymap;

        public DesktopInput(Keymap keymap)
        {
            this.keymap = keymap;
        }

        public void Tick()
        {
            DirectionButtons();

            ActionButtons();
        }

        private void DirectionButtons()
        {
            var direction = new Vector2();

            if (Input.GetKey(keymap.MoveLeftButton))
            {
                direction.x = -1;
            }

            if (Input.GetKey(keymap.MoveRightButton))
            {
                direction.x = 1;
            }

            if (Input.GetKey(keymap.MoveBackButton))
            {
                direction.y = -1;
            }

            if (Input.GetKey(keymap.MoveForwardButton))
            {
                direction.y = 1;
            }

            MoveDirection = direction;
        }

        private void ActionButtons()
        {
            if (Input.GetKeyDown(keymap.SprintButton))
            {
                StartSprint.Invoke();
            }

            if (Input.GetKeyUp(keymap.SprintButton))
            {
                StopSprint.Invoke();
            }

            if (Input.GetKeyDown(keymap.InterractButton))
            {
                Interract.Invoke();
            }

            if (Input.GetKeyDown(keymap.ThrowButton))
            {
                Throw.Invoke();
            }
        }
    }
}