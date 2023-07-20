using System.Collections.Generic;
using UnityEngine;
public class FallingAstroeids : MyRigidBody
{
    [field: SerializeField] public AudioSource CollisionExplosionSound { get; private set; }
    [field: SerializeField] public ParticleSystem CollisionExplosion { get; private set; }
    public Vector3 startingPoistion { get; private set; }

    protected override void Start()
    {
        base.Start();

        startingPoistion = transform.position;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        List<FallingAstroeids> myRigidBodies = GameManager.Instance.GetFallingAstroeidList();
        List<FallingAstroeids> CollidingFallingAstroeids = new List<FallingAstroeids>();
        WeaponAstroeid weaponAstroeid = GameManager.Instance.WeaponAstroeid;

        foreach (FallingAstroeids fallingAstroeid in myRigidBodies)
        {
            if (fallingAstroeid.IsCollidingWith(weaponAstroeid))
            {
                CollidingFallingAstroeids.Add(fallingAstroeid);

                fallingAstroeid.transform.position -= Accelration.normalized;

            }

        }

        foreach (FallingAstroeids FallingAstroeid in CollidingFallingAstroeids)
        {
            StartCoroutine(GameManager.Instance.DestroyFallingAstroeid(FallingAstroeid));
        }
    }
}

