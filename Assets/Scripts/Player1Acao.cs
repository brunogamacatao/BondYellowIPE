using UnityEngine;
using System.Collections;

public class Player1Acao : MonoBehaviour 
{
	public static bool cobras = false;

	public Transform hiBalloon;
	public Transform cantDoAnythingBalloon;
	public Transform gottaKillSnakesBalloon;

	public Transform balaPrefab;

	private Animator anim;
	private bool primeiro = true;
	private bool mostrouBalaoCobras = false;
	private bool podeAtirar = false;
	private Transform spawnEmPe;
	private Transform spawnAgachado;

	private bool direita = true;

	void Start() {
		anim = GetComponent<Animator> ();
		spawnEmPe = transform.Find ("SpawnPe");
		spawnAgachado = transform.Find ("SpawnAgachado");
	}

	public void ExecutaAcao () {
		if (primeiro) {
			primeiro = false;
			hiBalloon.renderer.enabled = true;
			StartCoroutine (EscondeBalao (hiBalloon));
		} else {
			if (!cobras) {
				cantDoAnythingBalloon.renderer.enabled = true;
				StartCoroutine (EscondeBalao (cantDoAnythingBalloon));
			} else {
				if (!mostrouBalaoCobras) {
					mostrouBalaoCobras = true;
					gottaKillSnakesBalloon.renderer.enabled = true;
					StartCoroutine (EscondeBalao (gottaKillSnakesBalloon));
				} else {
					podeAtirar = true;
				}
			}
		}
	}

	IEnumerator EscondeBalao(Transform balao) {
		yield return new WaitForSeconds(2);
		balao.renderer.enabled = false; 
	}

	void Update() {
		if (!podeAtirar || GameManagerScript.PERSONAGEM_ATUAL != 0) return;

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
