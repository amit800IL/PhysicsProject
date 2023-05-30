using UnityEngine;


public class MoveBlockers : MonoBehaviour
{
    private Vector3 platformStartingPos;
    private bool isMovingToTarget;
    [SerializeField] private Transform platform;
    [SerializeField] private Transform targetPos;
    [SerializeField] private float movementSpeed;
    [SerializeField] private MyRigidBody rigidBody;

    private void Start()
    {
        platformStartingPos = platform.position;
        isMovingToTarget = true;
    }

    private void Update()
    {
        //if (isMovingToTarget)
        //{
        //    rigidBody.ApplyMovement(platform.position, targetPos.position, movementSpeed * Time.deltaTime);

        //    if(Vector3.Distance(platform.position, targetPos.position) < 0.5f)
        //    {
        //        isMovingToTarget = false;
        //    }
        //}
        //else
        //{
        //    rigidBody.ApplyMovement(platform.position, platformStartingPos, movementSpeed * Time.deltaTime);

        //    if (Vector3.Distance(platform.position, platformStartingPos) < 0.5f)
        //    {
        //        isMovingToTarget = true;
        //    }
        //}
        
    }
}

