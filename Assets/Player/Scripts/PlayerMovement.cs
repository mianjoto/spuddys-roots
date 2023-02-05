using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Player Movement Settings
    [Header("Player Movement Settings")]
    [SerializeField] float _walkSpeed = 5f;
    [SerializeField] float _jumpForce = 6f;
    [SerializeField] float _fallGravityMultiplier = 4f;
    #endregion

    #region Raycast Checks
    [Header("Raycast Checks")]
    [SerializeField] LayerMask _groundLayerMask;
    [SerializeField] float _groundCheckDistance = 0.1f;
    #endregion

    Rigidbody2D _rb;
    Collider2D _col;
    bool _isGrounded;
    bool _isMovingHorizontally;
    bool _isHoldingJumpKey;
    bool _canClimb;

    #region Event Subscriptions
    void OnEnable()
    {
        InputListener.OnLeftKeyHold += MoveLeft;
        InputListener.OnRightKeyHold += MoveRight;
        InputListener.OnLeftKeyUp += StopMovingHorizontally;
        InputListener.OnRightKeyUp += StopMovingHorizontally;
        InputListener.OnJumpKeyDown += Jump;
        InputListener.OnJumpKeyUp += () => _isHoldingJumpKey = false;

        InputListener.OnUpKeyHold += Climb;
    }

    void OnDisable()
    {
        InputListener.OnLeftKeyHold -= MoveLeft;
        InputListener.OnRightKeyHold -= MoveRight;
        InputListener.OnLeftKeyUp -= StopMovingHorizontally;
        InputListener.OnRightKeyUp -= StopMovingHorizontally;
        InputListener.OnJumpKeyDown -= Jump;

        InputListener.OnUpKeyHold -= Climb;
    }
    #endregion

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }

    void Start()
    {
        _isGrounded = true;
        _isMovingHorizontally = false;
    }

    void FixedUpdate()
    {
        _isGrounded = IsGrounded();
        _isMovingHorizontally = IsMovingHorizontally();
        if (!_isGrounded)
            HandleFallAfterJump();
    }

    #region Walking Logic
    void MoveRight() => _rb.velocity = new Vector2(_walkSpeed, _rb.velocity.y);
    void MoveLeft() => _rb.velocity = new Vector2(-_walkSpeed, _rb.velocity.y);

    bool IsMovingHorizontally() => _rb.velocity.x != 0;
    void StopMovingHorizontally() => _rb.velocity += new Vector2(-_rb.velocity.x, 0);
    public void ResetVelocity() => _rb.velocity = Vector2.zero;
    #endregion

    #region Jumping Logic
    void Jump()
    {
        if (!_isGrounded)
            return;

        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        // Assume player will hold jump key after jump to jump higher, make false on jump key up event
        _isHoldingJumpKey = true;
    }

    bool IsGrounded()
    {
        Vector2 bottomOfPlayerPosition = GetGroundRaycastOrigin();
        RaycastHit2D hit = Physics2D.Raycast(bottomOfPlayerPosition, Vector2.down, 0.1f, _groundLayerMask);
        return hit.collider != null;
    }
    Vector2 GetGroundRaycastOrigin() => new Vector2(transform.position.x, transform.position.y - _col.bounds.extents.y);

    void HandleFallAfterJump()
    {
        // If player is falling, increase gravity fall faster
        if (_rb.velocity.y < 0)
            _rb.gravityScale = _fallGravityMultiplier;

        // If player is short jumping, increase gravity fall faster to shorten jump
        else if (_rb.velocity.y > 0 && !_isHoldingJumpKey)
            _rb.gravityScale = _fallGravityMultiplier;

        // If player is not falling, reset gravity
        else
            _rb.gravityScale = 1;
    }
    #endregion

    #region Climbing Logic
    public static bool CanClimb;
    void Climb()
    {
        if (!CanClimb) return;
        
        float climbDirection = Input.GetAxisRaw("Vertical");

        if (climbDirection > 0)
            _rb.velocity = new Vector2(0, _walkSpeed);
        else if (climbDirection < 0)
            _rb.velocity = new Vector2(0, -_walkSpeed);
        else
            _rb.velocity = new Vector2(0, 0);
    }
    #endregion
    void OnDrawGizmos()
    {
        if (transform == null || _col == null)
            return;

        // Groundcheck raycast
        Gizmos.color = Color.green;
        Gizmos.DrawRay(GetGroundRaycastOrigin(), Vector2.down * _groundCheckDistance);
    }
}