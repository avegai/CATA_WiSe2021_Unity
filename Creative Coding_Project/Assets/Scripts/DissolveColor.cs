using UnityEngine;


//This code was written by me while exploring how to create my own property binders. 
//The reason behind this was to be able to control specific parameters from the Shader Graph by the LASP plugin by Keijiro Takahashi, specifically the Audio Level Tracker.
//I created this property to have the transparency of the object be Audio Reactive. 
public class DissolveColor : MonoBehaviour
{
    public Material dissolveMat;
    public float c_Color = 0.1f;

    void Start()
    {
        dissolveMat.SetFloat("_DitherSize", c_Color);         
    }

    void Update()

    {
        dissolveMat.SetFloat("_DitherSize", c_Color);
    }

    public void modifyAlpha(float newAlpha)
    {
        c_Color = newAlpha;
    }
}