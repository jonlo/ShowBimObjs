using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtHvac : MonoBehaviour
{
	void FixedUpdate() {
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			HVACSceneObject sceneObject = hit.transform.gameObject.GetComponent<HVACSceneObject>();
		
			if (sceneObject != null) {
				Debug.Log("obj: " + sceneObject.id);
				PlayerControl.LookingAtHvac(sceneObject);
			}
			Debug.DrawRay(transform.position, transform.forward, Color.green);
		}
	}
}
