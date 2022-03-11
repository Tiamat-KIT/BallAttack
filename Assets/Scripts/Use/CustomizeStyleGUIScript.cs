using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeStyleGUIScript : MonoBehaviour
{
    GUIStyle labelStyle;

    void Start() {}

    void Update() {
        if(Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    void GuiSetup()
    {
        labelStyle = new GUIStyle();
        labelStyle.fontSize = 42;
        labelStyle.fontStyle = FontStyle.BoldAndItalic;
        labelStyle.normal.textColor = Color.cyan;
    }

    void OnGUI()
    {
        GuiSetup();
        GUI.Box (new Rect (10,10,700,100), "Message");
        GUI.Label (new Rect (35,50,700,50), 
            "ゲームクリア", labelStyle);
    }

}
