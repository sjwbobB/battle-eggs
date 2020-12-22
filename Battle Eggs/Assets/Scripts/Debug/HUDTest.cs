using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDTest : MonoBehaviour
{
    #region "Variables"
    public Texture2D texture;
    public Vector2 size;
    public bool relative;
    #endregion

    private Vector2 screenSize;

    void Update()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
    }

    void OnGUI()
    {
        // Draw specified texture, with size being relative based on the "Relative" checkbox
        GUI.DrawTexture(new Rect(Vector2.zero, relative ? size * screenSize : size), texture);
    }
}
