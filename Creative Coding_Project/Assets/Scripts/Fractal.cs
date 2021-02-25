
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fractal : MonoBehaviour
{
	public Mesh[] meshes;
	public Material material;
	public int maxDepth;
	public int deformerMaxDepth = 1; // new
	public float deformerSpringForce = 10f; // new
	public float deformerDamping = 1f; // new
	private int depth;
	public float childScale = 0.5f; 
	private Material[] materials;
	public float spawnProbability = 0.7f;
	public float maxRotationSpeed = 60f;
	private float rotationSpeed;
	public float maxTwist = 20f;
	

	private void InitializeMaterials () {
		materials = new Material[maxDepth + 1];
		for (int i = 0; i <= maxDepth; i++) {
            float t = i / (maxDepth - 1f);
			t *= t;
			materials[i] = new Material(material);
			//materials[i].color = Color.Lerp(Color.white, Color.yellow, t); 
		}
        //materials[maxDepth].color = Color.magenta; 
	}

	private void Start() {
		rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
		transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
		gameObject.AddComponent<MeshFilter>().mesh =
			meshes[Random.Range(0, meshes.Length)];
		if (materials == null) {
			InitializeMaterials();
		}
		gameObject.AddComponent<MeshRenderer>().material = materials[depth];
		if (depth < maxDepth) {
			StartCoroutine(CreateChildren());
		}
		if (depth <= deformerMaxDepth) // new
        {
			gameObject.AddComponent<MeshDeformer>();
			MeshDeformer deformer = gameObject.GetComponent<MeshDeformer>();
			deformer.damping = deformerDamping;
			deformer.springForce = deformerSpringForce;
			gameObject.AddComponent<BoxCollider>();
		}
	}
	private static Vector3[] childDirections = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back,
        Vector3.down
	};

	private static Quaternion[] childOrientations = {
		Quaternion.identity,
		Quaternion.Euler(0f, 0f, -90f),
		Quaternion.Euler(0f, 0f, 90f),
		Quaternion.Euler(90f, 0f, 0f),
		Quaternion.Euler(-90f, 0f, 0f),
        Quaternion.Euler(0f, 0f, -180f)
	};

	private IEnumerator CreateChildren () {
		for (int i = 0; i < childDirections.Length; i++) {
			if (Random.value < spawnProbability) {
				yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
				new GameObject("Fractal Child").AddComponent<Fractal>().
					Initialize(this, i);
			}
		}
	}

	private void Initialize (Fractal parent, int childIndex) {
		meshes = parent.meshes;
		materials = parent.materials;
		maxDepth = parent.maxDepth;
		deformerMaxDepth = parent.deformerMaxDepth; // new
		deformerDamping = parent.deformerDamping; // new
		deformerSpringForce = parent.deformerSpringForce; // new
		depth = parent.depth + 1;
		childScale = parent.childScale;
		spawnProbability = parent.spawnProbability;
		maxRotationSpeed = parent.maxRotationSpeed;
		maxTwist = parent.maxTwist; 
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = Vector3.up + childDirections[childIndex];
		transform.localRotation = childOrientations[childIndex];
	}
	private void Update () {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

}

