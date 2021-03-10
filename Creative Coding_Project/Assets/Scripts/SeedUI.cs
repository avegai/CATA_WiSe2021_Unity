using System;
using UnityEngine;

public class SeedUI : MonoBehaviour
{
    public Material accessSeed;
    public float modifySeed = 5f;

    void Start()
    {
        accessSeed.SetFloat("_Seed", modifySeed);         
    }

    private void Update()
    {
        accessSeed.SetFloat("_Seed", modifySeed);
    }

    public void changeSeed(float newSeed)
    {
        modifySeed = newSeed;
    }
}