using UnityEngine;

public class RotateToCamera : MonoBehaviour {

	// Update is called once per frame
	private void Update() {
		Vector3 n = Camera.main.transform.position - transform.position;
		transform.rotation = Quaternion.LookRotation(-n);
	}

}