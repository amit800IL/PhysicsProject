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
            Debug.Log("Entered Pull");
            NewRigidBody.PullandPush(cube.transform.position, transform.position);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Debug.Log("Entered Push");
            beenPulled = true;
            beenPushed = true;
            
        }

        if (!Mouse.current.leftButton.isPressed && beenPulled && beenPushed)
        {
            NewRigidBody.PullandPush(cube.transform.position, pulledPosition);
            beenPushed = false;
            beenPulled = false;
        }

    }

    //private void CubeToAcceptor()
    //{
    //    bool cubeToAcceptorRaycast = Physics.Raycast(cube.transform.position, acceptor.transform.position, distance);

    //    if (Mouse.current.leftButton.wasReleasedThisFrame & cubeToAcceptorRaycast)
    //    {
    //        cubeRigibBody.velocity = new Vector3(0, 10, -15);
    //        StartCoroutine(flyToAcceptor());
    //    }
    //}

    //private void CubeToCeiling()
    //{
    //    if (cube.transform.position == acceptor.transform.position)
    //    {
    //        StartCoroutine(FlyToCeilling());
    //    }
    //}
    //private IEnumerator flyToAcceptor()
    //{
    //    yield return new WaitForSeconds(2);
    //    Vector3.MoveTowards(cube.transform.position, acceptor.transform.position - cube.transform.position, movementSpeed * Time.deltaTime);
    //    cube.transform.position = acceptor.transform.position;

    //}

    //private IEnumerator FlyToCeilling()
    //{
    //    yield return new WaitForSeconds(2);
    //    Vector3.MoveTowards(cube.transform.position, ceillingObject.transform.position - cube.transform.position, movementSpeed * Time.deltaTime);
    //    cube.transform.position = ceillingObject.transform.position;
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(cube.transform.position, transform.position);
        //Gizmos.DrawLine(cube.transform.position, acceptor.transform.position);
        //Gizmos.DrawLine(cube.transform.position, ceillingObject.transform.position);
    }
}

