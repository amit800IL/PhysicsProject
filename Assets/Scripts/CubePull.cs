using UnityEngine;
using UnityEngine.InputSystem;

public class CubePull : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float distance;
    private void Update()
    {
        PullCube();
    }

    public void PullCube()
    {
        bool raycast = Physics.Raycast(cube.transform.position, transform.position - cube.transform.position);
        Debug.Log(raycast);
        if (Mouse.current.rightButton.isPressed && raycast)
        {
            Vector3.MoveTowards(cube.transform.position, transform.position, distance);
            cube.transform.Translate(transform.position);
            cube.transform.position = transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, cube.transform.position);
    }
}
