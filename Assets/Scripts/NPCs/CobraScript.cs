using UnityEngine;
using System.Collections;

public class CobraScript : MonoBehaviour {
	public float deslocamento = 5f;
	public int life = 3;

	private Animator anim;
	private float tempoUltimaColisao = 0;
	private float delayEntreColisoes = 1f;
	private bool imune = false;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (imune) {
			tempoUltimaColisao += Time.deltaTime;
			if (tempoUltimaColisao >= delayEntreColisoes) {
				imune = false;
			}
		}
	}

	void Move() {
		transform.Translate (Vector3.right * deslocamento * Time.deltaTime);
	}

	void Dano() {
		if (life > 0) {
			life--;
			anim.SetTrigger("atingida");
		}

		if (life <= 0) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		TrataColisoes (coll);
	}

	void OnCollisionStay2D(Collision2D coll) {
		TrataColisoes (coll);
	}

	void TrataColisoes(Collision2D coll) {
		if (coll.gameObject.tag == "Obstaculo") {
			Flip();
			deslocamento *= -1f;
			Move ();
		} else if (coll.gameObject.tag == "Player" && !imune) {
			imune = true;
			tempoUltimaColisao = 0;
			rigidbody2D.AddForce(new Vector2(-transform.localScale.x, 1f) * 10000);
			PlayerScript player = coll.gameObject.GetComponentInChildren<PlayerScript>();
			player.Atingido(1);
		}
	}

	void Flip() {
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
