using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: Header("Rigib bodies Refernces")]
    [field: SerializeField] public WeaponAstroeid WeaponAstroeid { get; private set; }
    public FallingAstroeids[] FallingAstroeids { get; private set; }

    private List<FallingAstroeids> FallingAstroeidList = new List<FallingAstroeids>();

    [field: Header("Player Scripts Refernces")]
    [field: SerializeField] public PlayerMovement Player { get; private set; }


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

        UpdateFallingAstroeidCollections();
    }
    public List<FallingAstroeids> GetFallingAstroeidList()
    {
        return FallingAstroeidList;
    }
    public void DestroyFallingAstroeid(FallingAstroeids astroeid)
    {
        FallingAstroeidList.Remove(astroeid);
        Destroy(astroeid.gameObject);
    }

    public void UpdateFallingAstroeidCollections()
    {
        FallingAstroeids = FindObjectsOfType<FallingAstroeids>();
        FallingAstroeidList = FallingAstroeids.ToList();
    }
}
