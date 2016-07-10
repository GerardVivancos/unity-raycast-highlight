using UnityEngine;
using System.Collections;

public class ClickToSelect : MonoBehaviour {

	private Ray shootRay;
	private RaycastHit shootHit;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		SphereCollider[] spheres = Object.FindObjectsOfType<SphereCollider>();

		foreach (SphereCollider sc in spheres) {
			sc.gameObject.GetComponent<MeshRenderer> ().materials [0].shader = Shader.Find ("Standard");

		}


		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100)) {
			Vector3 hitPoint = hit.point;
			float distance = Vector3.Distance (ray.origin, hitPoint);

			//Debug
			Debug.DrawRay(ray.origin, ray.direction * distance, Color.cyan, 0, true);
			//----

			if (hit.collider.gameObject.GetComponent<SphereCollider> ()) {
				MeshRenderer otherObjectMeshRenderer = hit.collider.gameObject.GetComponent<MeshRenderer> ();
				otherObjectMeshRenderer.materials [0].shader = Shader.Find ("Outlined/Silhouetted Diffuse");
			}
			if (Input.GetButtonDown("Fire1")) {
				transform.LookAt(hit.transform);
			}
		}

	}
}
