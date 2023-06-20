using UnityEngine;
using UnityEngine.InputSystem;

public class CubePull : MonoBehaviour
{
    [SerializeField] private GameObject astroeid;
    [SerializeField] private float distance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private MyRigidBody astroeidRigidBody;
    [SerializeField] private Vector3 pulledPosition;
    [SerializeField] private GameObject backGround;
    private void FixedUpdate()
    {
        PullCube();
    }

    private void PullCube()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            pulledPosition = astroeid.transform.position;
        }

        if (Mouse.current.leftButton.isPressed)
        {
            astroeidRigidBody.PullandPush(astroeid.transform.position, transform.position);
        }

        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,
            mousePos.y, Camera.main.nearClipPlane));
            astroeidRigidBody.PullandPush(pulledPosition, worldPoint);
        }

        if (!Mouse.current.rightButton.isPressed && !Mouse.current.leftButton.isPressed)
        {
            astroeidRigidBody.overrideForce = false;
        }
    }
}



