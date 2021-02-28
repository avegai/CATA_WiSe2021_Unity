using UnityEngine;

public class MeshDeformerPropertyBinder : MonoBehaviour
{

    //private float fuerza = 15f;
    public float fuerzaInvert = 0.5f;
    public Collider hitMat;

    public float fuerzaOffset

    {
        get
        {
            return fuerzaOffset;
        }

        private set
        {
            fuerzaOffset = value;
        }
    }

    void Start()
    {
        fuerzaOffset = 10f;
        Debug.Log(fuerzaOffset);
   
    }

    //void Update()
    //{
    //    Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;

    //    if (Colli.Raycast(inputRay, out hit))
    //    {
    //        MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
    //        if (deformer)
    //        {
    //            Vector3 point = hit.point;
    //            point += hit.normal * fuerza;
    //            deformer.AddDeformingForce(point, fuerza);
    //        }
    //    }


    //}
}
