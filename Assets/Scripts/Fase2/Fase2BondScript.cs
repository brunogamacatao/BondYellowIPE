using UnityEngine;
using System.Collections;

public class Fase2BondScript : MonoBehaviour {
	public Transform balaPrefab;
	
	private Animator anim;
	private Transform spawnEmPe;
	private Transform spawnAgachado;

	public Transform vilao;
	public Transform lookHeDroppedBalloon;
	
	private bool direita = true;
	private VilaoScript vilaoScript;
	
	void Start() {
		anim          = GetComponent<Animator> ();
		spawnEmPe     = transform.Find ("SpawnPe");
		spawnAgachado = transform.Find ("SpawnAgachado");
		vilaoScript   = vilao.GetComponent<VilaoScript> ();
	}
	
	public void ExecutaAcao () {
		if (vilaoScript.morto) {
			lookHeDroppedBalloon.renderer.enabled = true;
			StartCoroutine (EscondeBalao (lookHeDroppedBalloon));
		}
	}

	IEnumerator EscondeBalao(Transform balao) {
		yield return new WaitForSeconds(2);
		balao.renderer.enabled = false; 
	}

	
	void Update() {
		if (vilaoScript.morto) {
			SendMessage("LiberaAndar");
			anim.SetBool("atirando", false);

			return;
		}

		if (GameManagerScript.PERSONAGEM_ATUAL != 0) return;
		
		if (Input.GetButton("Acao")) {
			SendMessage("TravaAndar");
			anim.SetBool("atirando", true);
		} else {
			SendMessage("LiberaAndar");
			anim.SetBool("atirando", false);
		}
	}
	
	public void Dispara() {
		Transform bala;
		
		if (anim.GetBool("agachado")) {
			bala = (Transform)Instantiate (balaPrefab, spawnAgachado.position, transform.rotation);
			Destroy (bala.gameObject, 2f);
		} else {
			bala = (Transform)Instantiate (balaPrefab, spawnEmPe.position, transform.rotation);
			Destroy (bala.gameObject, 2f);
		}
		
		if (!direita) {
			BalaScript balaScript = bala.gameObject.GetComponent<BalaScript>();
			balaScript.velocidade *= -1;
		}
	}
	
	void LookLeft() {
		direita = false;
	}
	
	void LookRight() {
		direita = true;
	}
}
