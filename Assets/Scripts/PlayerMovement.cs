using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 newMove;
    private Vector3 moveInput;
    [SerializeField] private float groudDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rigibBody;
    [SerializeField] LayerMask GroundMask;
    [SerializeField] Transform groundCheck;

    private void Start()
    {
        newMove = moveInput.x * transform.right + moveInput.y * transform.forward;

        if (newMove.magnitude > 1)
        {
            newMove.Normalize();
        }
    }

    public void OnMove(InputValue value)
    {
        newMove = InputManager.Instance.GetMoveValue(value);

        newMove = new Vector3(-newMove.x, 0, -newMove.y);

        rigibBody.velocity = newMove * moveSpeed;
    }

    private void FixedUpdate()
    {
        if (newMove != null)
            rigibBody.AddForce(newMove * moveSpeed, ForceMode.Impulse);
    }

    public void IsGrounded() => Physics.CheckSphere(groundCheck.position, groudDistance, GroundMask);

}
