using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Basic Movement Variables
    [SerializeField] private float movementSpeed = 5f;
    public Rigidbody2D _rigidbody2d;
    private Vector2 movement;

    // Dashing Variables
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer _trailRenderer;

    // Slow Motion Skill Variables
    public TimeManager timeManager;

    // Shooting Skill Variables
    public Weapon weapon;
    public Camera camEarth;
    public Vector2 moveDirection;
    public Vector2 mousePosition;
    

    void Awake()
    {   
        // Rigidbody usage
        if(_rigidbody2d == null)
            _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        // Input Checking is happening here - thanks to GetAxisRaw() method here
        movement.x = Input.GetAxisRaw("Horizontal");    // A and D Keys are detected here
        movement.y = Input.GetAxisRaw("Vertical");      // W and S Keys are detected here

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Motion Slowed");
            timeManager.DoSlowMotion();
        }

        // For the Shooting Skill
        if (Input.GetMouseButtonDown(0))
        {
            weapon.FireBullet();
        }
        moveDirection = new Vector2(movement.x, movement.y).normalized;
        mousePosition = camEarth.ScreenToWorldPoint(Input.mousePosition);

        // For the Portal Opening
        if (Input.GetMouseButtonDown(1))
        {
            weapon.FirePortal();
        }
    }
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        // Player Movement is happening here - also movement.normalized helps to reduce advantage of diagonally faster movement (sqrt2 disabled)
        _rigidbody2d.MovePosition(_rigidbody2d.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
        //_rigidbody2d.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);

        // For the Shooting Skill
        Vector2 aimDirection = mousePosition - _rigidbody2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidbody2d.rotation = aimAngle;
    }

    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = _rigidbody2d.gravityScale;
        _rigidbody2d.gravityScale = 0f;
        _rigidbody2d.velocity = movement.normalized * dashingPower;
        _trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        _trailRenderer.emitting = false;
        _rigidbody2d.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
