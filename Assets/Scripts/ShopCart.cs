using System;
using UnityEngine;

public class ShopCart : MonoBehaviour
{
    public Action OnBagAdded, OnBottleAdded, OnBoxAdded;

    [SerializeField] private Collider col, triggerCol;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetPhysics(bool enabled)
    {
        // col.enabled = enabled;
        // triggerCol.enabled = !enabled;
        _rb.isKinematic = !enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out var item))
        {
            Debug.Log((item.IsPickedUp));
            if (item.IsPickedUp)
                return;
            switch (item.tag)
            {
                case "Bag":
                    OnBagAdded.Invoke();
                    break;
                case "Bottle":
                    OnBottleAdded.Invoke();
                    break;
                case "Box":
                    OnBoxAdded.Invoke();
                    break;
            }

            Destroy(item.gameObject);
        }
    }
}
