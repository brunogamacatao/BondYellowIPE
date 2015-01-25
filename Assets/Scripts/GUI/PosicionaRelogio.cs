using UnityEngine;
using System.Collections;

public class PosicionaRelogio : MonoBehaviour {
	public Vector2 offset;

	private GUITexture bg;
	private GUIText texto;
	private float tempoTotal = 0.0f;

	void Start () {
		bg = transform.FindChild("BG").guiTexture;
		texto = transform.FindChild("Texto").guiText;

		texto.pixelOffset = new Vector2(0 + offset.x, Screen.height - offset.y - 3);
		bg.pixelInset = new Rect (0 + offset.x - 3, Screen.height - bg.pixelInset.height - offset.y, bg.pixelInset.width, bg.pixelInset.height);
	}

	void Update () {
		tempoTotal += Time.deltaTime;

		string segundos = "" + (int)(tempoTotal % 60);
		string minutos  = "" + ((int)(tempoTotal) / 60);

		if (segundos.Length < 2) segundos = "0" + segundos;
		if (minutos.Length < 2)  minutos = "0" + minutos;
		if (minutos.Length > 2)  minutos = minutos.Substring(0, 2);

		texto.text = minutos + ":" + segundos;
	}
}
