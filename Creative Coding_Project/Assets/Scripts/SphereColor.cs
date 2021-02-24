//Attach this script to any GameObject in your scene to spawn a cube and change the material color
using UnityEngine;

public class SphereColor : MonoBehaviour
{
    private float _color;
    public Material dissolveMat;
    //public float Opacity;
    //public float maxOpacity;

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
        Debug.Log(c_Color);

        dissolveMat.SetFloat("_DitherSize", c_Color);
         
    }

    void Update()

    {
        dissolveMat.SetFloat("_DitherSize", c_Color);
       //transform.localScale = new Vector3(c_Color, c_Color, c_Color);

    }
}