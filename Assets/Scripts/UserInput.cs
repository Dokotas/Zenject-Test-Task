using UnityEngine;

public class UserInput : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    private Vector2 _moveVector;

    void Start()
    {
        // Debug.Log(Application.isMobilePlatform);

    }

    void Update()
    {
        _moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _moveVector.Normalize();
        playerController.SetMoveDirection(_moveVector);

        if (Input.GetKeyDown(KeyCode.LeftControl))
            playerController.Dash();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            playerController.Sprint(true);

        if (Input.GetKeyUp(KeyCode.LeftShift))
            playerController.Sprint(false);

        if (Input.GetKeyDown(KeyCode.E))
            playerController.Interact();

        if (Input.GetKeyDown(KeyCode.F))
            playerController.Throw();
    }
}
