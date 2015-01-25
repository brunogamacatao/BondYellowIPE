using UnityEngine;
using System.Collections;

public class ExitAction : MonoBehaviour, AcaoIF {
	private bool first = true;
	
	public void Executa () {
		if (first) {
			first = false;
			SendMessageUpwards ("FadeOut", this);
		} else {
			Application.Quit();
		}
	}
}
