using UnityEngine;
using System.Collections;
using TMPro;

public class FPSCounter : MonoBehaviour
{
	public TextMeshProUGUI fpsCounter;
	public TextMeshProUGUI msCounter;
	private float deltaTime = 0.0f;

	void Update()
	{
		// Update delta time every frame
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;

		string ftext = string.Format("{0:0.0}", msec);
		string mtext = string.Format("{0:0.}", fps);
		fpsCounter.text = ftext;
		msCounter.text = mtext;
	}
}
