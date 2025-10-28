using UnityEngine;

namespace PhotonTestTask
{
    [CreateAssetMenu(fileName = "KeymapData", menuName = "Input/Keymap")]
    public sealed class Keymap : ScriptableObject
    {
        public KeyCode MoveForwardButton, MoveLeftButton, MoveBackButton, MoveRightButton;
        public KeyCode SprintButton, InterractButton, ThrowButton;
    }
}