using UnityEngine;
using System.Collections;

public class StartAction : MonoBehaviour, AcaoIF {
	public string firstLevel;

	private bool first = true;

	public void Executa () {
		if (first) {
			first = false;
			SendMessageUpwards ("FadeOut", this);
		} else {
			Application.LoadLevel (firstLevel);
		}
	}
}
