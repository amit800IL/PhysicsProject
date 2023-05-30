using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 newMove;
    private Vector2 moveInput;
    [SerializeField] private float groudDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rigibBody;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private Transform groundCheck;

    private void Start()
    {
        IsGrounded();

        newMove = moveInput.x * transform.right + moveInput.y * transform.forward;

        if (newMove.magnitude > 1)
        {
            newMove.Normalize();
        }
    }

    private void OnMove(InputValue value)
    {
        newMove = InputManager.Instance.GetMoveValue(value);

        newMove = new Vector2(newMove.x, newMove.y);

        rigibBody.velocity = newMove * moveSpeed;
    }

    private void FixedUpdate()
    {
        if (newMove != null)
            rigibBody.AddForce(newMove * moveSpeed, ForceMode2D.Impulse);
    }

    public void IsGrounded() => Physics.CheckSphere(groundCheck.position, groudDistance, GroundMask);

}
