using UnityEngine;
using System.Collections;

public class Player2Acao : MonoBehaviour {
	
	public Transform hiBalloon;
	public Transform interestingPillar;
	public Transform foundAStone;

	private bool primeiro = true;
	
	public void ExecutaAcao () {	
		if (primeiro) {
			primeiro = false;
			hiBalloon.renderer.enabled = true;
			StartCoroutine (EscondeBalao (hiBalloon));
		} else {
			if (!Fase1MScript.jaDeuADicaDaColuna) {
				interestingPillar.renderer.enabled = true;
				StartCoroutine (EscondeBalao (interestingPillar));

				Fase1MScript.jaDeuADicaDaColuna = true;
			}

			if (Fase1MScript.jaDeuADicaDaColuna && Fase1MScript.naColuna) {
				foundAStone.renderer.enabled = true;
				StartCoroutine (EscondeBalao (foundAStone));

				Fase1QScript.mMandouQIrNaColuna = true;
			}
		}
	}
	
	IEnumerator EscondeBalao(Transform balao) {
		yield return new WaitForSeconds(2);
		balao.renderer.enabled = false; 
	}


}
