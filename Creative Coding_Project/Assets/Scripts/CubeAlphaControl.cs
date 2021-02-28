using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAlphaControl : MonoBehaviour
{
    private float alphaCube;
    public Material seeThruFactor;
    
    void Start()
    {
        // seeThruFactor.SetFloat("_AlphaFactor", a_Alpha);        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            seeThruFactor.SetFloat("_AlphaFactor", Random.Range(0.1f, 0.9f));
        }
            
    }
}
