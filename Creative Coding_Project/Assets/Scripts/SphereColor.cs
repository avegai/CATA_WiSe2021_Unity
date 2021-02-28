using UnityEngine;

public class SphereColor : MonoBehaviour
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