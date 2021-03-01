using UnityEngine;

//The following script was a simple rotation script I wrote from scratch to implement some custom made code. 
//I attached this script to a few of the objects to give it some rotation while in Game Mode

public class RotationScript : MonoBehaviour
{
   public float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);

        transform.Rotate(Vector3.right * speed * Time.deltaTime);

        transform.Rotate(Vector3.down * speed * 5 * Time.deltaTime);
        
    }
}
 