using UnityEngine;
using System.Collections;

public class TutorialAction : MonoBehaviour, AcaoIF {
	public string tutorialLevel;
	
	private bool first = true;
	
	public void Executa () {
		if (first) {
			first = false;
			SendMessageUpwards ("FadeOut", this);
		} else {
			Application.LoadLevel (tutorialLevel);
		}
	}
}
