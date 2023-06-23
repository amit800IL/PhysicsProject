using System.Collections.Generic;


public class FallingAstroeids : MyRigidBody
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        List<FallingAstroeids> myRigidBodies = GameManager.Instance.GetFallingAstroeidList();
        WeaponAstroeid weaponAstroeid = GameManager.Instance.WeaponAstroeid;
        List<FallingAstroeids> CollidingFallingAstroeids = new List<FallingAstroeids>();

        foreach (FallingAstroeids fallingAstroeid in myRigidBodies)
        {
            if (fallingAstroeid.IsCollidingWith(weaponAstroeid))
            {
                CollidingFallingAstroeids.Add(fallingAstroeid);
            }
        }

        foreach (FallingAstroeids FallingAstroeid in CollidingFallingAstroeids)
        {
            GameManager.Instance.DestroyFallingAstroeid(FallingAstroeid);
        }
    }
}

