using UnityEngine;

public class MoveBlockers : MonoBehaviour
{
    private Vector3 platformStartingPos;
    private bool isMovingToTarget;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform targetPos;
    [SerializeField] private float movementSpeed;

    private void Start()
    {
        platformStartingPos = platform.position;
        isMovingToTarget = true;
    }

    private void Update()
    {
        if (isMovingToTarget)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos.position, movementSpeed * Time.deltaTime);

            if(Vector3.Distance(platform.position, targetPos.position) < 0.5f)
            {
                isMovingToTarget = false;
            }
        }
        else
        {
            platform.position = Vector3.MoveTowards(platform.position, platformStartingPos, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(platform.position, platformStartingPos) < 0.5f)
            {
                isMovingToTarget = true;
            }
        }
        
    }
}

