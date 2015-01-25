using UnityEngine;
using System.Collections;

public class Fase1NPC : MonoBehaviour {
	public Transform cobraPrefab;
	public Transform cobraSpawn;
	public float delayInicial;
	public float delay;

	void Start() {
		StartCoroutine (ComecaDroparCobras ());
	}

	IEnumerator ComecaDroparCobras() {
		yield return new WaitForSeconds(delayInicial);
		Debug.Log ("ComecaDroparCobras");
		Player1Acao.cobras = true;
		StartCoroutine(DropCobra ());
	}

	IEnumerator DropCobra() {
		Debug.Log ("DropCobra");
		Instantiate (cobraPrefab, cobraSpawn.position, cobraSpawn.rotation);
		yield return new WaitForSeconds(delay);
		StartCoroutine (DropCobra ());
	}
}
