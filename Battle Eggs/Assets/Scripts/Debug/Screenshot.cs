using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    #region "Variables"
    public string fileName = "screenshot.png";
    #endregion

    void FixedUpdate()
    {
        // Capture screenshots with F12
        if (Input.GetKeyDown(KeyCode.F12))
            ScreenCapture.CaptureScreenshot("Assets/Screenshots/" + fileName);
    }
}
