using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCursor : MonoBehaviour
{
    public int cursorSize;

    public Texture2D cursor;

    void FixedUpdate()
    {
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int halfCurSize = cursorSize / 2;

        Vector2 aimPos = Input.mousePosition;
        aimPos.y = Screen.height - aimPos.y;

        GUI.DrawTexture(new Rect(aimPos.x - halfCurSize, aimPos.y - halfCurSize, cursorSize, cursorSize), cursor);
    }
}
