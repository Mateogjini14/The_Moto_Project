using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custom_cursor : MonoBehaviour
{
    public Texture2D cursor;
    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

}
