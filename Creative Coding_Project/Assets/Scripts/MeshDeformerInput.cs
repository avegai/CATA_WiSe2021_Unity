using UnityEngine;

//This script is also based of a catlikecoding coding tutorial we did in class (https://catlikecoding.com/unity/tutorials/mesh-deformation/)
//This script must be attached to the main camera or whatever object is connecting the input to the Unity environment.  

public class MeshDeformerInput : MonoBehaviour
{

    public float force = 10f;
    public float forceOffset = 0.1f;

	void Update()
	{
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }

	void HandleInput() 
	//The mouse clicks are being read by this script to make so everytime the main mouse button clicks the sphere, it deforms it.
	//It works in tandem with the MeshDeformer Script

	{
		
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
		{
			MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();

			if (deformer)

			{
				Vector3 point = hit.point;
				point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
			}
		}
	}

}
