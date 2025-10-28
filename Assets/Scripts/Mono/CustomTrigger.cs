using UnityEngine;
using System;

namespace PhotonTestTask
{
    public sealed class CustomTrigger : MonoBehaviour
    {
        public event Action<int> Entered;
        public event Action<int> Exited;

        private int _id;

        public void Init(int id)
        {
            _id = id;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Entered.Invoke(_id);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Exited.Invoke(_id);
            }
        }

        public void ForceEnter()
        {
            Entered.Invoke(_id);
        }

        public void ForceExit()
        {
            Exited.Invoke(_id);
        }
    }
}
