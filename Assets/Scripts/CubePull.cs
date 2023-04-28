using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CubePull : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Rigidbody cubeRigibBody;
    [SerializeField] private GameObject acceptor;
    [SerializeField] private GameObject ceillingObject;
    [SerializeField] private float distance;
    [SerializeField] private float movementSpeed;
    private void Update()
    {
        PullCube();
        CubeToAcceptor();
        CubeToCeiling();
    }

    private void PullCube()
    {
        bool cubeToPlayerRaycast = Physics.Raycast(cube.transform.position, transform.position, distance);

        if (Mouse.current.leftButton.isPressed && cubeToPlayerRaycast)
        {
            Vector3.MoveTowards(cube.transform.position, transform.position - cube.transform.position, movementSpeed * Time.deltaTime);
            cube.transform.position = transform.position;
        }

    }

    private void CubeToAcceptor()
    {
        bool cubeToAcceptorRaycast = Physics.Raycast(cube.transform.position, acceptor.transform.position, distance);

        if (Mouse.current.leftButton.wasReleasedThisFrame & cubeToAcceptorRaycast)
        {
            cubeRigibBody.velocity = new Vector3(0, 10, -15);
            StartCoroutine(flyToAcceptor());
        }
    }

    private void CubeToCeiling()
    {
        if (cube.transform.position == acceptor.transform.position)
        {
            StartCoroutine(FlyToCeilling());
        }
    }
    private IEnumerator flyToAcceptor()
    {
        yield return new WaitForSeconds(2);
        Vector3.MoveTowards(cube.transform.position, acceptor.transform.position - cube.transform.position, movementSpeed * Time.deltaTime);
        cube.transform.position = acceptor.transform.position;

    }

    private IEnumerator FlyToCeilling()
    {
        yield return new WaitForSeconds(2);
        Vector3.MoveTowards(cube.transform.position, ceillingObject.transform.position - cube.transform.position, movementSpeed * Time.deltaTime);
        cube.transform.position = ceillingObject.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(cube.transform.position, transform.position);
        Gizmos.DrawLine(cube.transform.position, acceptor.transform.position);
        Gizmos.DrawLine(cube.transform.position, ceillingObject.transform.position);
    }
}

