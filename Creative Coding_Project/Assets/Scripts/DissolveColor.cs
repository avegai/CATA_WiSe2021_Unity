using UnityEngine;


//This code was written by me while exploring how to create my own property binders. 
//The reason behind this was to be able to control specific parameters from the Shader Graph by the LASP plugin by Keijiro Takahashi, specifically the Audio Level Tracker.
//I created this property to have the transparency of the object be Audio Reactive. 
public class DissolveColor : MonoBehaviour
{
    private float _color;
    public Material dissolveMat;
  
    public float c_Color

    {
        get
        {
            return _color;
        }

        private set
        {
            _color = value;
        }
    }

    void Start()
    {
        c_Color = 10f;
        //Debug.Log(c_Color);

        dissolveMat.SetFloat("_DitherSize", c_Color);         
    }

    void Update()

    {
        dissolveMat.SetFloat("_DitherSize", c_Color);
    }
}