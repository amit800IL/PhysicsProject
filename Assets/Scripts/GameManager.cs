using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public FallingAstroeids[] FallingAstroeids { get; private set; }
    [field: SerializeField] public MyRigidBody WeaponAstroeid { get; private set; }

    [field: Header("Player Scripts Refernces")]
    [field: SerializeField] public PlayerMovement Player { get; private set; }
    [field: SerializeField] public WeaponAstroeid PlayerCubePull { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        FallingAstroeids = FindObjectsOfType<FallingAstroeids>();
    }
}
