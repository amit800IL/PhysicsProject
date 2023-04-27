using UnityEditor;
using UnityEngine;

public class CubeWindReaction : MonoBehaviour
{
    [SerializeField] private Rigidbody cubeRigibBody;
    [SerializeField] private WindZone windZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wind"))
        {
            Debug.Log("Detected");
            cubeRigibBody.AddForce(50,0,0, ForceMode.Impulse);
        }
    }
}

