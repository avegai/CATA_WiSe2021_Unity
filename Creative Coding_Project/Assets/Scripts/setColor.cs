using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public Material rainbowCube;
    public float hue = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rainbowCube.SetFloat("_hue", hue);         
    }

    // Update is called once per frame

    void Update()
    {
        rainbowCube.SetFloat("_hue", hue);         
    }
    public void GetColor(float newColor)
    {
        hue = newColor;
    }
}
