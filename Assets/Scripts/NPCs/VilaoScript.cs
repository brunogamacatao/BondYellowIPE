using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VilaoScript : MonoBehaviour {
	public float forcaAndar = 300f;
	public float velocidadeMaxima = 1f;

	public Transform[] spawnRegions;
	public Transform[] players;

	private Animator anim;

	private float respawnDelay = 5f;
	private float respawnTimer = 0f;

	private Transform chasing;

	public int lifeParaRespawn = 2;
	private int lifeRespawn = 0;
	public int maxRespawn = 10;
	private int qtdRespawn = 0;

	private float tempoUltimaColisao = 0;
	private float delayEntreColisoes = 1f;
	private bool imune = false;

	public bool morto;

	void Start() {
		morto = false;
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (morto) return;

		if (imune) {
			tempoUltimaColisao += Time.deltaTime;
			if (tempoUltimaColisao >= delayEntreColisoes) {
				imune = false;
			}
		}

		Respawn ();
		Chase ();
	}

	void ChoosePlayerToChase() {
		float minDistance = Vector3.Distance(transform.position, players[0].position);
		Transform goingToChase = players [0];

		foreach (Transform player in players) {
			float d = Vector3.Distance(transform.position, player.position);
			if (d < minDistance) {
				minDistance = d;
				goingToChase = player;
			}
		}

		chasing = goingToChase;
	}

	void Chase() {
		if (chasing == null) {
			ChoosePlayerToChase();
		}

		if (transform.position.x < chasing.position.x) { // Se o vilao esta na esquerda
			if (Mathf.Abs(rigidbody2D.velocity.x) < velocidadeMaxima) {
				rigidbody2D.AddForce(Vector2.right * forcaAndar);
			}
		} else if (transform.position.x > chasing.position.x) { // Se o vilao esta na direita
			if (Mathf.Abs(rigidbody2D.velocity.x) < velocidadeMaxima) {
				rigidbody2D.AddForce(-1 * Vector2.right * forcaAndar);
			}
		}
	}

	void Respawn () {
		respawnTimer += Time.deltaTime;
		if (respawnTimer >= respawnDelay) {
			respawnTimer = 0f;
			
			List<Transform> possibleRespawns = new List<Transform>();
			
			foreach (Transform spawn in spawnRegions) {
				SpawnCheck check = spawn.GetComponent<SpawnCheck>();
				if (check.IsFree()) {
					possibleRespawns.Add(spawn);
				}
			}
			
			int spawnToGoIndex = Random.Range(0, possibleRespawns.Count);
			Transform spawnToGo = possibleRespawns[spawnToGoIndex];
			
			transform.position = CloneVector3(spawnToGo.position);
			chasing = null;
		}
	}

	Vector3 CloneVector3(Vector3 o) {
		return new Vector3 (o.x, o.y, o.z);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		TrataColisoes (coll);
	}
	
	void OnCollisionStay2D(Collision2D coll) {
		TrataColisoes (coll);
	}
	
	void TrataColisoes(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && !imune) {
			imune = true;
			tempoUltimaColisao = 0;

			rigidbody2D.AddForce(new Vector2(-transform.localScale.x, 1f) * 200);
			PlayerScript player = coll.gameObject.GetComponentInChildren<PlayerScript>();
			player.Atingido(2);
		}
	}

	void Dano() {
		anim.SetTrigger ("atingido");

		lifeRespawn++;
		if (lifeRespawn > lifeParaRespawn) {
			qtdRespawn++;

			if (qtdRespawn >= maxRespawn) {
				anim.SetTrigger("morrer");
				morto = true;
				rigidbody2D.isKinematic = true;
				transform.FindChild("GroundCheck").GetComponent<BoxCollider2D>().enabled = false;
			} else {
				lifeRespawn = 0;
				respawnTimer = respawnDelay + 1;
			}
		}
	}
}
