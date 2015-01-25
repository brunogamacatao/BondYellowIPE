using UnityEngine;
using System.Collections;

public class Fase2MScript : MonoBehaviour {
	public static bool JA_VIU_O_VILAO = false;

	public Transform vilao;
	public Transform hesGonnaKillUsBalloon;
	public Transform letMeSeeBalloon;
	public Transform qComeHereBalloon;
	
	private VilaoScript vilaoScript;
	private bool noVilao;

	void Start() {
		noVilao = false;
		vilaoScript = vilao.GetComponent<VilaoScript> ();
		JA_VIU_O_VILAO = true;
	}
	
	public void ExecutaAcao () {
		if (!vilaoScript.morto) {
			hesGonnaKillUsBalloon.renderer.enabled = true;
			StartCoroutine (EscondeBalao (hesGonnaKillUsBalloon));
		} else {
			if (noVilao) {
				qComeHereBalloon.renderer.enabled = true;
				StartCoroutine (EscondeBalao (qComeHereBalloon));
				JA_VIU_O_VILAO = true;
			} else {
				letMeSeeBalloon.renderer.enabled = true;
				StartCoroutine (EscondeBalao (letMeSeeBalloon));
				noVilao = true;
			}
		}
	}
	
	IEnumerator EscondeBalao(Transform balao) {
		yield return new WaitForSeconds(2);
		balao.renderer.enabled = false; 
	}

/*	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "NPC") noVilao = true;
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "NPC") noVilao = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "NPC") noVilao = false;
	}*/

}
