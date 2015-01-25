using UnityEngine;
using System.Collections;

public class Player3Acao : MonoBehaviour {
	
	public Transform hiBalloon;
	public Transform justLooking;
	public Transform foundAPlace;
	public Transform goToPillar;
	public Transform foundAKey;
	public Transform chave;

	private bool primeiro = true;
	
	public void ExecutaAcao () {	
		if (primeiro) {
			primeiro = false;
			hiBalloon.renderer.enabled = true;
			StartCoroutine (EscondeBalao (hiBalloon));
		} else {
			if (Fase1QScript.fezAChave) {
				if (!Fase1QScript.naPorta) {
					foundAPlace.renderer.enabled = true;
					StartCoroutine (EscondeBalao (foundAPlace));
				} else {
					Debug.Log("Abre a porta");
					GameManagerScript.PERSONAGEM_ATUAL = 0;
					Application.LoadLevel("Fase1Congrats");

					Fase1QScript.fezAChave = false;

					Fase1QScript.naPorta = false;
					Fase1QScript.naColuna = false;
					Fase1QScript.mMandouQIrNaColuna = false;
					Fase1MScript.naColuna = false;
					Fase1MScript.jaDeuADicaDaColuna = false;
				}
			} else {
				if (!Fase1QScript.mMandouQIrNaColuna) {
					justLooking.renderer.enabled = true;
					StartCoroutine (EscondeBalao (justLooking));
				} else {
					if (!Fase1QScript.naColuna) {
						goToPillar.renderer.enabled = true;
						StartCoroutine (EscondeBalao (goToPillar));
					} else {
						foundAKey.renderer.enabled = true;
						StartCoroutine (EscondeBalao (foundAKey));
						Fase1QScript.fezAChave = true;
						chave.renderer.enabled = true;
					}
				}
			}
		}
	}
	
	IEnumerator EscondeBalao(Transform balao) {
		yield return new WaitForSeconds(2);
		balao.renderer.enabled = false; 
	}

}
