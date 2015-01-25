using UnityEngine;
using System.Collections;

public class PositionAndResize : MonoBehaviour {
	private GUITexture fadeMask;

	public float fadeSpeed = 0.7f;

	private bool fading  = true;
	private bool fadeOut = false;
	private AcaoIF toExecute;

	void Start () {
		Screen.showCursor = true;

		fadeMask = transform.FindChild ("FadeMask").guiTexture;

		float width  = (float)Screen.currentResolution.width;
		float height = (float)Screen.currentResolution.height;
		float x = -(float)width / 2.0f;
		float y = -(float)height / 2.0f;
		
		fadeMask.pixelInset = new Rect (x, y, width, height);
		fadeMask.color = new Color(fadeMask.color.r, fadeMask.color.g, fadeMask.color.b, 1.0f);

		//SpriteFunctions.ResizeSpriteToScreen(gameObject, Camera.main, 0, 1);
	}
	
	void Update () {
		if (fading) {
			if (fadeMask.color.a > 0.0f) {
				fadeMask.color = SubAlpha(fadeMask.color, -fadeSpeed * Time.deltaTime);
			} else {
				fading = false;
			}
		}
		
		if (fadeOut) {
			if (fadeMask.color.a < 1.0f) {
				fadeMask.color = SubAlpha(fadeMask.color, fadeSpeed * Time.deltaTime);
			} else {
				toExecute.Executa();
			}
		}
	}

	public void FadeOut(AcaoIF acao) {
		toExecute = acao;
		fadeOut = true;
	}
	
	Color SubAlpha(Color c, float dAlpha) {
		return new Color(c.r, c.g, c.b, c.a + dAlpha);
	}
}
