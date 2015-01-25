using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	private GUITexture fadeMask;
	private GUITexture splash;

	public float fadeInSpeed = 0.7f;
	public float delayLogo   = 1.0f;

	private bool fading  = true;
	private bool fadeOut = false;
	private float tempoTotalLogo = 0.0f;

	void Start () {
		Screen.showCursor = false;

		fadeMask = transform.FindChild ("FadeMask").guiTexture;
		splash = transform.FindChild ("Logo").guiTexture;

		float width  = (float)Screen.currentResolution.width;
		float height = (float)Screen.currentResolution.height;
		float x = -(float)width / 2.0f;
		float y = -(float)height / 2.0f;
		
		fadeMask.pixelInset = new Rect (x, y, width, height);
		fadeMask.color = new Color(fadeMask.color.r, fadeMask.color.g, fadeMask.color.b, 1.0f);

		splash.pixelInset = new Rect ((width - splash.pixelInset.width) /2, splash.pixelInset.height, splash.pixelInset.width, splash.pixelInset.height);
	}
	
	void Update () {
		if (fading) {
			if (fadeMask.color.a > 0.0f) {
				fadeMask.color = SubAlpha(fadeMask.color, -fadeInSpeed * Time.deltaTime);
			} else {
				fading = false;
			}
		} else {
			tempoTotalLogo += Time.deltaTime;
			if (tempoTotalLogo >= delayLogo) {
				fadeOut = true;
			}
		}

		if (fadeOut) {
			if (fadeMask.color.a < 1.0f) {
				fadeMask.color = SubAlpha(fadeMask.color, fadeInSpeed * Time.deltaTime);
			} else {
				Application.LoadLevel("Menu");
			}
		}
	}

	Color SubAlpha(Color c, float dAlpha) {
		return new Color(c.r, c.g, c.b, c.a + dAlpha);
	}
}
