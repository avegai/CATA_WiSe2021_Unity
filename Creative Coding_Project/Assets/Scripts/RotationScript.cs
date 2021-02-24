using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //transform.localScale = new Vector3(Random.RandomRange(-1f, 1f), 0.5f, 0.5f);
    }
}
 