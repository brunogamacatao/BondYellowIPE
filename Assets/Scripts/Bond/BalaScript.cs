using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour {
	public float velocidade;

	void Update () {
		transform.Translate (Vector3.right * velocidade * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "NPC") {
			other.gameObject.SendMessage("Dano");
			Destroy(gameObject);
		}
	}
}
