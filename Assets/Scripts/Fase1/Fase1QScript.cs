using UnityEngine;
using System.Collections;

public class Fase1QScript : MonoBehaviour {
	public static bool mMandouQIrNaColuna = false;
	public static bool fezAChave = false;

	public static bool naColuna = false;
	public static bool naPorta  = false;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.collider2D.gameObject.name == "Coluna") {
			naColuna = true;
		} else if (other.collider2D.gameObject.name == "Porta") {
			naPorta = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.collider2D.gameObject.name == "Coluna") {
			naColuna = false;
		} else if (other.collider2D.gameObject.name == "Porta") {
			naPorta = false;
		}
	}
}
