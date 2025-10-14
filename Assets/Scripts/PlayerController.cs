using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, sprintSpeed, dashForce;
    [SerializeField] private Transform handsWithItem, handsOnShopCart;

    private Shelf _nearestShelf;
    private Item _item, _nearestItem;
    private ShopCart _shopCart, _nearestShopCart;

    private Vector2 _direction;
    private bool _isSprinting, _isCarrying;

    private Rigidbody _rb;
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    public void SetMoveDirection(Vector2 direction)
    {
        if (_isSprinting && !_isCarrying)
            _direction = direction * sprintSpeed;
        else
            _direction = direction * speed;
    }

    public void Dash()
    {
        // _rb.AddForce(transform.forward * dashForce);
    }

    public void Interact()
    {
        if (_isCarrying)
            Drop();
        else
            PickUp();
    }

    public void PickUp()
    {
        if (_nearestShopCart != null)
        {
            _shopCart = _nearestShopCart;
            _nearestShopCart = null;

            _shopCart.SetPhysics(false);
            _shopCart.transform.parent = handsOnShopCart;
            _shopCart.transform.localPosition = Vector3.zero;
            _shopCart.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        else if (_nearestItem != null)
        {
            _item = _nearestItem;
            _nearestItem = null;

            _item.PickUp();
            _item.transform.parent = handsWithItem;
            _item.transform.localPosition = Vector3.zero;
            _item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        else if (_nearestShelf != null)
        {
            _item = _nearestShelf.GetItem();
            _item.PickUp();
            _item.transform.parent = handsWithItem;
            _item.transform.localPosition = Vector3.zero;
            _item.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        else
        {
            return;
        }

        _isCarrying = true;
        _animator.Play("pick up");
    }

    public void Drop()
    {
        _isCarrying = false;

        if (_shopCart != null)
        {
            _shopCart.SetPhysics(true);
            _shopCart.transform.parent = null;
            _shopCart = null;
        }

        else if (_item != null)
        {
            _item.Drop(transform.forward);
            _item.transform.parent = null;
            _item = null;
        }

        _animator.Play("idle");
    }

    public void Throw()
    {
        if (!_isCarrying)
            return;

        _isCarrying = false;
        _item.transform.parent = null;
        _item.Throw(transform.forward);
        _animator.Play("throw");
    }

    public void Sprint(bool sprinting)
    {
        _isSprinting = sprinting;
        _animator.SetBool("Sprinting", _isSprinting);
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", _rb.linearVelocity.magnitude);

        _rb.linearVelocity = new Vector3(_direction.x, _rb.linearVelocity.y, _direction.y);

        if (_direction != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.y));
            _rb.angularVelocity = Vector3.zero;
            // _rb.MoveRotation(Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.y)));

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Shelf>(out var shelf))
        {
            _nearestShelf = shelf;
        }
        if (other.TryGetComponent<Item>(out var item))
        {
            _nearestItem = item;
        }
        if (other.TryGetComponent<ShopCart>(out var shopCart))
        {
            _nearestShopCart = shopCart;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Shelf>(out var shelf))
        {
            if (_nearestShelf == shelf)
                _nearestShelf = null;
        }
        if (other.TryGetComponent<Item>(out var item))
        {
            if (_nearestItem == item)
                _nearestItem = null;
        }
        if (other.TryGetComponent<ShopCart>(out var shopCart))
        {
            if (_nearestShopCart == shopCart)
                _nearestShopCart = null;
        }
    }
}
