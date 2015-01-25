using UnityEngine;
using System.Collections;

public class ProximoLevel : MonoBehaviour {
	public string proximoLevel;

	void Start() {
		Screen.showCursor = false;
	}

	void Update() {
		if (Input.anyKeyDown) {
			Muda();
		}
	}

	void Muda () {
		Application.LoadLevel (proximoLevel);
	}
}
