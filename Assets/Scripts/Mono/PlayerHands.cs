using UnityEngine;

namespace PhotonTestTask
{
    public sealed class PlayerHands : MonoBehaviour
    {
        [field: SerializeField] public Transform HandsWithItem { get; private set; }
        [field: SerializeField] public Transform HandsOnCart { get; private set; }
    }
}