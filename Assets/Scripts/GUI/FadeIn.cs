using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float fadeInSpeed = 0.1f;

	void Start () {
		float width  = (float)Screen.currentResolution.width;
		float height = (float)Screen.currentResolution.height;
		float x = -(float)width / 2.0f;
		float y = -(float)height / 2.0f;

		guiTexture.pixelInset = new Rect (x, y, width, height);
		guiTexture.color = new Color(guiTexture.color.r, guiTexture.color.g, guiTexture.color.b, 1.0f);
	}

	void Update () {
		if (guiTexture.color.a > 0.0f) {
			guiTexture.color = SubAlpha(guiTexture.color, -fadeInSpeed * Time.deltaTime);
		}
	}

	Color SubAlpha(Color c, float dAlpha) {
		return new Color(c.r, c.g, c.b, c.a + dAlpha);
	}
}
