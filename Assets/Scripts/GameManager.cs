using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: Header("Rigib bodies Refernces")]
    [field: SerializeField] public WeaponAstroeid WeaponAstroeid { get; private set; }
    [field: SerializeField] public FallingAstroeids[] FallingAstroeids { get; private set; }

    [field: SerializeField] private List<FallingAstroeids> FallingAstroeidList = new List<FallingAstroeids>();

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
    public IEnumerator DestroyFallingAstroeid(FallingAstroeids astroeid)
    {
        astroeid.CollisionExplosion.gameObject.SetActive(true);
        astroeid.CollisionExplosion.Play();
        astroeid.CollisionExplosionSound.Play();
        FallingAstroeidList.Remove(astroeid);
        yield return new WaitForSeconds(0.8f);
        astroeid.gameObject.SetActive(false);
    }

    public void UpdateFallingAstroeidCollections()
    {
        FallingAstroeids = FindObjectsOfType<FallingAstroeids>();
        FallingAstroeidList = FallingAstroeids.ToList();
    }
}
