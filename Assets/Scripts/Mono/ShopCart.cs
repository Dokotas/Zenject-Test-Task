using PhotonTestTask;
using System;
using UnityEngine;

public class ShopCart : MonoBehaviour
{
    public Action OnBagAdded, OnBottleAdded, OnBoxAdded;

    [SerializeField] private Collider col;

    private Rigidbody _rb;

    public ShopCart Item => this;

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
        if (other.TryGetComponent<Goods>(out var item))
        {
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
