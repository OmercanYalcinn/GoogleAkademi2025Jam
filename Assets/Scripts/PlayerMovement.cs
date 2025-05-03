using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    public Rigidbody2D _rigidbody2d;
    private Vector2 movement;

    void Awake()
    {   
        // Rigidbody usage
        if(_rigidbody2d == null)
            _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input Checking is happening here - thanks to GetAxisRaw() method here
        movement.x = Input.GetAxisRaw("Horizontal");    // A and D Keys are detected here
        movement.y = Input.GetAxisRaw("Vertical");      // W and S Keys are detected here
    }
    void FixedUpdate()
    {
        // Player Movement is happening here - also movement.normalized helps to reduce advantage of diagonally faster movement (sqrt2 disabled)
        _rigidbody2d.MovePosition(_rigidbody2d.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }
}
