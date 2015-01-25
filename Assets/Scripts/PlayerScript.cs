using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Animator anim;
	public Rigidbody2D player;
	public int numeroDoPersonagem;
	public float forcaAndar       = 100.0f;
	public float velocidadeMaxima = 2.0f;
	public float forcaPulo        = 10000.0f;
	public int life = 100;

	private bool indoParaDireita = true;
	private Transform groundCheck;
	private bool grounded;
	private bool agachado = false;
	private bool podeAndar = true;

	void Start () {
		groundCheck = transform.Find ("GroundCheck");
	}
	
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Chao"));

		anim.SetBool("andando", Mathf.Abs(player.velocity.x) > 0.1f);

		if (numeroDoPersonagem == GameManagerScript.PERSONAGEM_ATUAL) {
			float dx = Input.GetAxis ("Horizontal");

			CorrigeDirecao(dx);

			if (!agachado && podeAndar) {
				Anda(dx);
				Pula();
			}

			Agacha();

			if (Input.GetButtonDown("Acao")) {
				SendMessage("ExecutaAcao");
			}
		}
	}

	public void Atingido(int dano) {
		anim.SetTrigger ("atingido");
		life -= dano;
		if (life <= 0) {
			Application.LoadLevel("GameOver");
		}
	}

	void Anda(float dx) {
		if (dx != 0 && Mathf.Abs(player.velocity.x) < velocidadeMaxima) {
			player.AddForce(new Vector2(dx * forcaAndar, 0.0f));
		}
	}

	void Pula() {
		if (Input.GetButtonDown("Pulo") && grounded) {
			player.AddForce(new Vector2(0.0f, forcaPulo));
		}
	}

	void Agacha() {
		agachado = Input.GetButton ("Agacha") && grounded;
		anim.SetBool("agachado", agachado);
	}

	void CorrigeDirecao(float dx) {
		if (dx < 0 && indoParaDireita) {
			Flip ();
			indoParaDireita = false;
			SendMessage("LookLeft", SendMessageOptions.DontRequireReceiver);
		}
		
		if (dx > 0 && !indoParaDireita) {
			Flip();
			indoParaDireita = true;
			SendMessage("LookRight", SendMessageOptions.DontRequireReceiver);
		}
	}

	void Flip() {
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void TravaAndar() {
		podeAndar = false;
	}

	void LiberaAndar() {
		podeAndar = true;
	}
}
