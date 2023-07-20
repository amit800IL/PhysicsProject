using UnityEngine;

public abstract class MyRigidBody : MonoBehaviour
{
    [HideInInspector] public bool overrideForce;
    [HideInInspector] public Vector3 velocity;
    public Vector3 Accelration { get => force / mass; }
    protected float gravity = 9.8f;
    protected bool IsGrounded;
    [SerializeField] protected Vector3 force;
    [SerializeField] protected float mass;
    [SerializeField] protected float radius;
    [SerializeField] protected float Distance;
    [SerializeField] protected bool useGravity;
    [SerializeField] protected float moveSpeed;
    protected bool UseGravity
    {
        get => useGravity;

        set
        {
            useGravity = value;
        }
    }

    protected virtual void Start()
    {
        ApplyGravity();
    }
    protected virtual void FixedUpdate()
    {
        Accelrate();
        CheckCollision();
        UpdatePosition();
    }

    protected void ApplyGravity()
    {
        if (UseGravity)
        {
            force += gravity * Vector3.down;
        }
    }

    protected void Accelrate()
    {
        velocity += Accelration * Time.fixedDeltaTime;
    }

    protected void PullandPush(Vector3 startPos, Vector3 endPos)
    {

        overrideForce = true;

        Vector3 direction = Vector3.Normalize(endPos - startPos);
        direction.z = 0;

        transform.position += direction * moveSpeed * Time.fixedDeltaTime;

    }

    protected void CheckCollision()
    {
        MyRigidBody[] rigidBodyObjects = FindObjectsOfType<MyRigidBody>();

        foreach (MyRigidBody otherObject in rigidBodyObjects)
        {
            if (otherObject != this && IsCollidingWith(otherObject))
            {
                handeCollision(otherObject);
            }
        }
    }

    protected bool IsCollidingWith(MyRigidBody otherObjects)
    {
        float CombiendRadius = radius + otherObjects.radius;

        float distance = Vector3.Distance(transform.position, otherObjects.transform.position);

        return distance <= CombiendRadius;
    }

    protected void handeCollision(MyRigidBody otherObjects)
    {
        float combinedMass = mass + otherObjects.mass;
        float combiendRadius = radius + otherObjects.radius;

        Vector3 relativeVelocity = velocity - otherObjects.velocity;

        //This is a clacultion for when the objects collide they get force addition on both sides
        //The object that collides with the other object gets slower slower using its mass and impuslse
        //The other object gets faster and takes in the collision impact

        float arbitaryMultipiction = 50f;

        float impulseMagnitude = (arbitaryMultipiction * combiendRadius * relativeVelocity.magnitude) / (combinedMass * combiendRadius);

        Vector3 impulse = impulseMagnitude * relativeVelocity.normalized;

        velocity -= (impulse / mass);

        otherObjects.velocity += (impulse / otherObjects.mass);

        //not allowing the object to create overallay on each other after collision detection

        Vector3 seprationDirection = (transform.position - otherObjects.transform.position).normalized;

        float seperationDistnace = combiendRadius - Vector3.Distance(transform.position, otherObjects.transform.position);

        transform.position += (seprationDirection) * (seperationDistnace / 2f);
        otherObjects.transform.position -= (seprationDirection) * (seperationDistnace / 2f);
    }

    protected void UpdatePosition()
    {
        if (!overrideForce)
        {
            transform.position += velocity * Time.fixedDeltaTime;
        }
    }

}




