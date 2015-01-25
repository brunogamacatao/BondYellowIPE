using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {
	private float tempo;

	public string levelName;
	public float delay = 10f;
	
	void Start() {
		if (GameScript.Instance != null) GameScript.Instance.TocarMusica();
		Screen.showCursor = false;
	}
	
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel(levelName);
		}
		
		tempo += Time.deltaTime;
		if (tempo >= delay) {
			Application.LoadLevel(levelName);
		}
	}}
