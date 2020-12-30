using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public KeyCode key;
    public string fileName = "screenshot.png";

    void FixedUpdate()
    {
        // Capture screenshots with F12
        if (Input.GetKeyDown(key))
            ScreenCapture.CaptureScreenshot("Assets/Screenshots/" + fileName);
    }
}
