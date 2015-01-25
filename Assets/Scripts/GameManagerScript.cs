using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public static int PERSONAGEM_ATUAL = 0;
	public int numPersonagens = 3;

	public Transform[] players;

	void Start() {
		if (GameScript.Instance != null) GameScript.Instance.PararMusica ();
		Screen.showCursor = false;
	}

	void Update () {
		if (Input.GetButtonDown("TrocaPersonagem")) {
			players[PERSONAGEM_ATUAL].transform.Find("Seta").renderer.enabled = false;
			PERSONAGEM_ATUAL = (PERSONAGEM_ATUAL + 1) % numPersonagens;
			players[PERSONAGEM_ATUAL].transform.Find("Seta").renderer.enabled = true;

			// Toca o som do personagem atual
			players[PERSONAGEM_ATUAL].audio.Play();

			SmoothCamera2D smoothCamera = Camera.main.GetComponent<SmoothCamera2D>();
			smoothCamera.target = players[PERSONAGEM_ATUAL];
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			audio.Stop();
			if (GameScript.Instance != null) GameScript.Instance.TocarMusica();
			Application.LoadLevel("Menu");
		}
	}
}
