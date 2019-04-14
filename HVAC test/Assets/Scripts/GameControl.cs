using UnityEngine;

public class GameControl : MonoBehaviour {

	// Update is called once per frame
	private void Update() {
		if (Input.GetMouseButtonDown(1)) {
			PlayerControl.ShowAllHvacs();
		}
	}

}