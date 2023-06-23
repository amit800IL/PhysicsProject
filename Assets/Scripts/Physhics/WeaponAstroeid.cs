using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAstroeid : MyRigidBody
{
    private Vector3 pulledPosition;
    [SerializeField] private float distance;
    [SerializeField] private float movementSpeed;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        PullCube();
    }

    private void PullCube()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            pulledPosition = GameManager.Instance.Player.transform.position;
        }

        if (Mouse.current.leftButton.isPressed)
        {
            GameManager.Instance.WeaponAstroeid.PullandPush(transform.position, GameManager.Instance.Player.transform.position);
        }

        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,
            mousePos.y, Camera.main.nearClipPlane));
            GameManager.Instance.WeaponAstroeid.PullandPush(pulledPosition, worldPoint);
        }

        if (!Mouse.current.rightButton.isPressed && !Mouse.current.leftButton.isPressed)
        {
            GameManager.Instance.WeaponAstroeid.overrideForce = false;
        }
    }
}



