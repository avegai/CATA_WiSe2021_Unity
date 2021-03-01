using UnityEngine;

//This script is based of a catlikecoding coding tutorial we did in class (https://catlikecoding.com/unity/tutorials/mesh-deformation/)

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour
{
	public float springForce = 10f;
	public float damping;

	//I coded this property binder called "resorte" to add it to the AudioLevelTracker object and make it Audio Reactive.
	//This specific parameter is affecting the amount of spring-like effect of the mesh deformation. 
	public float resorte

    {
        get
        {
            return damping;
        }

        private set
        {
            damping = value;
        }
    }
    
    Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;
	Vector3[] vertexVelocities;

    float uniformScale = 1f;

	void Start()
	{
		deformingMesh = GetComponent<MeshFilter>().mesh;
		originalVertices = deformingMesh.vertices;
		displacedVertices = new Vector3[originalVertices.Length];
		for (int i = 0; i < originalVertices.Length; i++)
		{
			displacedVertices[i] = originalVertices[i];
		}
		vertexVelocities = new Vector3[originalVertices.Length];
	}

	public void AddDeformingForce(Vector3 point, float force)
	{
		point = transform.InverseTransformPoint(point);
		for (int i = 0; i < displacedVertices.Length; i++)
		{
			AddForceToVertex(i, point, force);
		}
	}

	void AddForceToVertex(int i, Vector3 point, float force)
	{
		Vector3 pointToVertex = displacedVertices[i] - point;
		pointToVertex *= uniformScale;
		float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
		float velocity = attenuatedForce * Time.deltaTime;
		vertexVelocities[i] += pointToVertex.normalized * velocity;
	}

    private void Update()
    
	{
		uniformScale = transform.localScale.x;
		for (int i = 0; i < displacedVertices.Length; i++)
		{
			UpdateVertex(i);
		}
		deformingMesh.vertices = displacedVertices;
		deformingMesh.RecalculateNormals();
	}

	void UpdateVertex(int i)
	{
		Vector3 velocity = vertexVelocities[i];
		Vector3 displacement = displacedVertices[i] - originalVertices[i];
		displacement *= uniformScale;
		velocity -= displacement * springForce * Time.deltaTime;
		velocity *= 1f - resorte * Time.deltaTime;
		vertexVelocities[i] = velocity;
		displacedVertices[i] += velocity * (Time.deltaTime / uniformScale);
	}

}
