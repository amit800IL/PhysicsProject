using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MyRigidBody
{
    private Vector2 newMove;
    private Vector2 moveInput;

    protected override void Start()
    {
        base.Start();

        newMove = moveInput.x * transform.right + moveInput.y * transform.forward;

        if (newMove.magnitude > 1)
        {
            newMove.Normalize();
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (newMove != null)
            force = newMove * moveSpeed * Accelration;
    }


    private void OnMove(InputValue value)
    {
        newMove = InputManager.Instance.GetMoveValue(value);

        newMove = new Vector2(newMove.x, newMove.y);

        velocity = newMove * moveSpeed;
    }

}
