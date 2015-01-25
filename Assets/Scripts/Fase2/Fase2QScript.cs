using UnityEngine;
using System.Collections;

public class Fase2QScript : MonoBehaviour {
	public static bool GO_TO_THE_POLE = false;

	public Transform vilao;
	public Transform killHimBond;
	public Transform iDontKnow;
	public Transform foundIt;
	public Transform takeMeCloser;

	public Transform[] cenarios;
	
	private VilaoScript vilaoScript;
	private bool noVilao;
	private bool noPoste;

	void Start() {
		GO_TO_THE_POLE = false;
		noVilao = false;
		noPoste = false;
		vilaoScript = vilao.GetComponent<VilaoScript> ();
	}
	
	public void ExecutaAcao () {
		if (GO_TO_THE_POLE && noPoste) {
			FimDaFase();
		} else {
			if (!vilaoScript.morto) {
				killHimBond.renderer.enabled = true;
				StartCoroutine (EscondeBalao (killHimBond));
			} else {
				if (!Fase2MScript.JA_VIU_O_VILAO) {
					iDontKnow.renderer.enabled = true;
					StartCoroutine (EscondeBalao (iDontKnow));
				} else {
					if (!noVilao) {
						noVilao = true;
						takeMeCloser.renderer.enabled = true;
						StartCoroutine (EscondeBalao (takeMeCloser));
					} else {
						foundIt.renderer.enabled = true;
						StartCoroutine (EscondeBalao (foundIt));
						GO_TO_THE_POLE = true;
						noPoste = true;
					}
				}
			}
		}
	}

	void FimDaFase() {
		foreach (Transform cenario in cenarios) {
			Animator a = cenario.GetComponent<Animator>();
			a.SetTrigger("sos");
		}
		StartCoroutine (TrocaDeCena ());
	}

	IEnumerator TrocaDeCena() {
		yield return new WaitForSeconds (5.3f);
		Application.LoadLevel ("Fase2Congrats");
	}
	
	IEnumerator EscondeBalao(Transform balao) {
		yield return new WaitForSeconds(2);
		balao.renderer.enabled = false; 
	}

/*	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "NPC") noVilao = true;
		if (other.gameObject.name == "Poste") noPoste = true;
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "NPC") noVilao = true;
		if (other.gameObject.name == "Poste") noPoste = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "NPC") noVilao = false;
		if (other.gameObject.name == "Poste") noPoste = false;
	}*/

}
