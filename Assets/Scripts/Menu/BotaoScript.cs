using UnityEngine;
using System.Collections;

public class BotaoScript : MonoBehaviour {
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void OnMouseDown  () {
		anim.SetBool ("pressed", true);
		SendMessage ("Executa");
	}

	void OnMouseUp() {
		anim.SetBool ("pressed", false);
	}
	
	void OnMouseEnter () {
		anim.SetBool ("over", true);
	}

	void OnMouseExit () {
		anim.SetBool ("over", false);
	}
}
