using UnityEngine;

public class Item : MonoBehaviour
{
    public bool IsPickedUp { get; private set; }

    [SerializeField] private float dropForce, throwForce;
    [SerializeField] private Collider col, triggerCol;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        SetPhysics(false);
    }

    public void PickUp()
    {
        IsPickedUp = true;
        SetPhysics(false);
    }

    public void Throw(Vector3 direction)
    {
        SetPhysics(true);

        _rb.AddForce(direction * throwForce);
    }

    public void Drop(Vector3 direction)
    {
        SetPhysics(true);

        _rb.AddForce(direction * dropForce);
    }

    private void SetPhysics(bool enabled)
    {
        col.enabled = enabled;
        triggerCol.enabled = !enabled;
        _rb.isKinematic = !enabled;
    }
}
