using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    bool onButton;

    public Texture2D cursor_normal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursor_OnButton;
    public Vector2 onButtonCursorHotSpot;


    // Update is called once per frame
    void Update()
    {
        if (!onButton)
        {
            Cursor.SetCursor(cursor_normal, normalCursorHotSpot, CursorMode.Auto);
        }
    }

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_OnButton, onButtonCursorHotSpot, CursorMode.Auto);
        onButton = true;
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursor_normal, normalCursorHotSpot, CursorMode.Auto);
        onButton = false;
    }

}
