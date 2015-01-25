using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	private static GameScript instance = null;

	public static GameScript Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	public void TocarMusica () {
		audio.Play ();
	}

	public void PararMusica () {
		audio.Stop ();
	}
}
