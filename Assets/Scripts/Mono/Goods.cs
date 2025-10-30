using UnityEngine;
using Zenject; 

namespace Market
{
    public sealed class Goods : MonoBehaviour, ITriggerable<Goods>
    {
        public class Pool : MonoMemoryPool<Goods>
        {
            private readonly CustomTriggerHandler<Goods> _customTriggerHandler;

            public Pool(CustomTriggerHandler<Goods> customTriggerHandler)
            {
                _customTriggerHandler = customTriggerHandler;
            }

            protected override void OnCreated(Goods item)
            {
                base.OnCreated(item);
                _customTriggerHandler.AddTriggerable(item);
            }

            protected override void OnSpawned(Goods item)
            {
                base.OnSpawned(item);
            }

            protected override void OnDespawned(Goods item)
            {
                item.CustomTrigger.ForceExit();
                base.OnDespawned(item);
            }
        }

        public Transform ParentContainer { get; set; }
        public Goods Component => this;
        public GoodsType Type { get; set; }
        public bool IsPickedUp { get; private set; }
        public CustomTrigger CustomTrigger { get; set; }


        [SerializeField] private Collider col, triggerCol;

        [SerializeField] private Rigidbody _rb;


        private void Start()
        {
            SetPhysics(false);
        }

        public void PickUp(Transform hands)
        {
            transform.parent = hands;
            transform.localPosition = new Vector3(0.248f, 0, -0.127f);
            transform.localRotation = Quaternion.Euler(0, 55.34f, 0);   

            IsPickedUp = true;
            SetPhysics(false);
        }

        public void Post(Vector3 force)
        {
            transform.parent = ParentContainer;
            IsPickedUp = false;
            SetPhysics(true);
            _rb.AddForce(force);
        }

        private void SetPhysics(bool physicsEnabled)
        {
            col.enabled = physicsEnabled;
            //triggerCol.enabled = physicsEnabled;
            _rb.isKinematic = !physicsEnabled;
        }
    }
}
