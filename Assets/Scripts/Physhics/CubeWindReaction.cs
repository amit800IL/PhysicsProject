using UnityEditor;
using UnityEngine;

public class CubeWindReaction : MonoBehaviour
{
    [SerializeField] private Rigidbody cubeRigibBody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wind"))
        {
            cubeRigibBody.AddForce(50,0,0, ForceMode.Impulse);
        }
    }
}

