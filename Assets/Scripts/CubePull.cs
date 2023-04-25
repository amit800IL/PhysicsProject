using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubePull : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Rigidbody cubeRigibBody;
    [SerializeField] private GameObject acceptor;
    [SerializeField] private GameObject ceillingObject;
    [SerializeField] private float distance;
    private void Update()
    {
        PullCube();
        CubeToAcceptor();
    }

    public void PullCube()
    {
        bool cubeToPlayerRaycast = Physics.Raycast(cube.transform.position, transform.position, distance);
     

        if (Mouse.current.leftButton.isPressed && cubeToPlayerRaycast)
        {
            Vector3.MoveTowards(cube.transform.position, transform.position - cube.transform.position, distance);
            cube.transform.position = transform.position;
        }

    

    }

    public void CubeToAcceptor()
    {
        bool cubeToAcceptorRaycast = Physics.Raycast(cube.transform.position, acceptor.transform.position, distance);

        if (Mouse.current.leftButton.wasReleasedThisFrame & cubeToAcceptorRaycast)
        {
            cubeRigibBody.velocity = new Vector3(0, 10, 0);
            StartCoroutine(flyToAcceptor());
            if (cube.transform.position == acceptor.transform.position)
            {
                StartCoroutine(FlyToCeilling());
            }
        }
    }

    private IEnumerator flyToAcceptor()
    {
        yield return new WaitForSeconds(5);
        Vector3.MoveTowards(cube.transform.position, acceptor.transform.position - cube.transform.position, distance);
        cube.transform.position = acceptor.transform.position;
        
    }

    private IEnumerator FlyToCeilling()
    {
        yield return new WaitForSeconds(5);
        cubeRigibBody.useGravity = false;
        Vector3.MoveTowards(cube.transform.position, ceillingObject.transform.position - acceptor.transform.position, distance);
        cube.transform.position = ceillingObject.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(cube.transform.position, transform.position);
        Gizmos.DrawLine(cube.transform.position, acceptor.transform.position);
        Gizmos.DrawLine(cube.transform.position, ceillingObject.transform.position);
    }
}
