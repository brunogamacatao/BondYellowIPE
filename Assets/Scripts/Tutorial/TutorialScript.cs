using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
	public string previousLevel;

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel(previousLevel);
		}
	}
}
