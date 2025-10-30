using UnityEngine;

namespace Market
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public sealed class PlayerConfig : ScriptableObject
    {
        public float walkSpeed, sprintSpeed, rotationSpeed, dropForce, throwForce;
    }
}