using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {
	public Transform player;

	private PlayerScript playerScript;
	private int maxLife;

	void Start () {
		playerScript = player.GetComponent<PlayerScript> ();
		maxLife = playerScript.life;
	}
	
	void Update () {
		transform.localScale = new Vector3 ((float)playerScript.life / (float)(maxLife), 1f, 1f);
	}
}
