using Unity.VisualScripting;
using UnityEngine;

public class MyRigidBody : MonoBehaviour
{
    public Vector3 Accelration { get => force / mass; }
    [HideInInspector] public bool overrideForce;

    private float gravity = 9.8f;
    private bool IsGrounded;
    [HideInInspector] public Vector3 velocity;
    [SerializeField] private Vector3 force;
    [SerializeField] private float mass;
    [SerializeField] private float radius;
    [SerializeField] private float Distance;
    [SerializeField] private bool useGravity;
    [SerializeField] private float moveSpeed;
    public bool UseGravity
    {
        get => useGravity;

        set
        {
            useGravity = value;
            Debug.Log(value);
        }
    }

    private void Start()
    {
        ApplyGravity();
    }
    private void FixedUpdate()
    {
        Accelrate();
        CheckCollision();
        UpdatePosition();
    }

    public void ApplyGravity()
    {
        if (UseGravity)
        {
            force += gravity * Vector3.down;
        }
    }

    public void Accelrate()
    {
        velocity += Accelration * Time.fixedDeltaTime;
    }

    public void PullandPush(Vector3 startPos, Vector3 endPos)
    {

        overrideForce = true;

        Vector3 direction = Vector3.Normalize(endPos - startPos);
        direction.z = 0;

        transform.position += direction * moveSpeed * Time.fixedDeltaTime;

    }

    private void CheckCollision()
    {
        MyRigidBody[] rigidBodyObjects = FindObjectsOfType<MyRigidBody>();

        foreach (MyRigidBody otherObject in rigidBodyObjects)
        {
            if (otherObject != this && IsCollidingWith(otherObject))
            {
                Debug.Log("Collision Handeled");
                handeCollision(otherObject);
            }
        }
    }

    private bool IsCollidingWith(MyRigidBody otherObjects)
    {
        float CombiendRadius = radius + otherObjects.radius;

        float distance = Vector3.Distance(transform.position, otherObjects.transform.position);

        return distance <= CombiendRadius;
    }

    private void handeCollision(MyRigidBody otherObjects)
    {
        float combinedMass = mass + otherObjects.mass;
        float combinedRadius = radius + otherObjects.radius;

        Vector3 relativeVelocity = velocity - otherObjects.velocity;

        float impulseMagnitude = (2 * combinedMass * relativeVelocity.magnitude) / (combinedMass * combinedRadius);
        Vector3 impulse = impulseMagnitude * relativeVelocity.normalized;

        velocity -= (impulse / mass);
        otherObjects.velocity += (impulse / otherObjects.mass);
    }

    private void UpdatePosition()
    {
        if (!overrideForce)
            transform.position += velocity * Time.fixedDeltaTime;
    }

}




