using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubePull : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float distance;
    private void Update()
    {
        bool raycast = Physics.Raycast(cube.transform.position, transform.position - cube.transform.position);

        if (Mouse.current.rightButton.isPressed && raycast)
        {
            Vector3.MoveTowards(cube.transform.position,transform.position, distance);
            cube.transform.Translate(transform.position);
            cube.transform.position = transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, cube.transform.position);
    }
}
