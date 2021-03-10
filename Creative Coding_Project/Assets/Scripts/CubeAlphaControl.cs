using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The following code was written by me  so I could control the Alpa parameter on the Cube's Shader.

public class CubeAlphaControl : MonoBehaviour
{
    private float alphaCube;
    public Material seeThruFactor;
    
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Everytime the user presses "A" it triggers a random number between 0.1 and 0.9.
            //The higer the value, the more transparent it gets.
            changeAlpha();
        }
            
    }

    public void changeAlpha()
    {
        seeThruFactor.SetFloat("_AlphaFactor", Random.Range(0.1f, 0.9f)); 
    }
}
