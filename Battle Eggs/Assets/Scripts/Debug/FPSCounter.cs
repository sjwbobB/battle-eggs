using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{
	private float deltaTime = 0.0f;

	void Update()
	{
		// Update delta time every frame
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		// Get ms and fps
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;

		int w = Screen.width, h = Screen.height;

		// Set style for label font
		GUIStyle style = new GUIStyle();
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = 24;
		style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

		// Rectangle for label drawing
		Rect rect = new Rect(0, 0, w, style.fontSize);

		// Draw label with text "<ms> ms (<fps> fps)"
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
	}
}
