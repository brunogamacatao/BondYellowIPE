using UnityEngine;
using System.Collections;

public class Fase1MScript : MonoBehaviour {
	public static bool naColuna = false;
	public static bool jaDeuADicaDaColuna = false;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.collider2D.gameObject.name == "Coluna") {
			naColuna = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.collider2D.gameObject.name == "Coluna") {
			naColuna = false;
		}
	}
}
