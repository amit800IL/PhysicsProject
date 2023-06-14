using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubePull : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float distance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private MyRigidBody NewRigidBody;
    [SerializeField] private Vector3 pulledPosition;
    [SerializeField] private bool beenPulled;
    [SerializeField] private bool beenPushed;
    private void FixedUpdate()
    {
        PullCube();
    }

    private void PullCube()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            pulledPosition = cube.transform.position;
        }

        if (Mouse.current.leftButton.isPressed)
        {
            NewRigidBody.PullandPush(cube.transform.position, transform.position);
        }

        if (Mouse.current.rightButton.isPressed)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log("target pos " + worldPoint);
            NewRigidBody.PullandPush(worldPoint, cube.transform.position);
        }
    }

}



