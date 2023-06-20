using UnityEngine;


public class MoveBlockers : MonoBehaviour
{
    [SerializeField] private MyRigidBody rigid;

    private void Start()
    {
        rigid.ApplyGravity();
    }

}

