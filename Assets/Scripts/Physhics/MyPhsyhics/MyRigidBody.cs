using UnityEngine;
using UnityEngine.InputSystem;

public class MyRigidBody : MonoBehaviour
{
    private float gravity = 9.8f;
    private bool IsGrounded;
    private Vector3 velocity;
    [SerializeField] private Vector3 force;
    [SerializeField] private float mass;
    [SerializeField] private float radius;
    [SerializeField] private Vector3 Accelration;
    [SerializeField] private float Distance;
    [SerializeField] private bool UseGravity;

    private void FixedUpdate()
    {
        ApplyGravity();
        ApplyForce();
        CheckCollision();
        UpdatePosition();
    }

    public void ApplyGravity()
    {
        if (UseGravity)
        {
            force += gravity * Vector3.down * Time.fixedDeltaTime;
        }
    }

    public void ApplyForce()
    {
        velocity += force * Time.fixedDeltaTime;
    }


    public void PullandPush(Vector3 startPos, Vector3 endPos)
    {
   
        Vector3 direction = Vector3.Normalize(endPos - startPos);
        direction.z = 0;

        force = gravity * direction;

    }

    public void CheckCollision()
    {
        MyRigidBody[] rigidBodyObjects = FindObjectsOfType<MyRigidBody>();

        foreach (MyRigidBody otherObject in rigidBodyObjects)
        {
            if (otherObject != this && IsCollidingWith(otherObject))
            {
                Debug.Log("Collistion Handling");
                handeCollision(otherObject);
            }
        }
    }

    public bool IsCollidingWith(MyRigidBody otherObjects)
    {
        float CombiendRadius = radius + otherObjects.radius;

        float distance = Vector3.Distance(transform.position, otherObjects.transform.position);

        return distance <= CombiendRadius;
    }

    public void handeCollision(MyRigidBody otherObjects)
    {
        Vector3 tempVelocity = velocity;
        velocity = otherObjects.velocity;
        otherObjects.velocity = tempVelocity;

        force = gravity * velocity;

    }

    public void UpdatePosition()
    {
        transform.position += velocity * Time.fixedDeltaTime;
    }
}




