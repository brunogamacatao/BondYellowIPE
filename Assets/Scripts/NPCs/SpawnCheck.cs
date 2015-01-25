using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCheck : MonoBehaviour {
	private HashSet<string> players = new HashSet<string>();

	public bool IsFree() {
		return players.Count == 0;
	}

	void OnTriggerEnter2D(Collider2D other) {
		players.Add (other.gameObject.name);
	}

	void OnTriggerStay2D(Collider2D other) {
		players.Add (other.gameObject.name);
	}

	void OnTriggerExit2D(Collider2D other) {
		players.Remove (other.gameObject.name);
	}
}
