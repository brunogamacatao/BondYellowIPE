using UnityEngine;
using System.Collections;

public class PositionGameOver : MonoBehaviour {
	private float tempo;

	void Start() {
		Screen.showCursor = false;
	}

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel("Splash");
		}

		tempo += Time.deltaTime;
		if (tempo >= 5.0f) {
			Application.LoadLevel("Splash");
		}
	}
}
