using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStyle : MonoBehaviour
{
    GUIStyle labelStyle;
    GUIStyle btnStyle;
    string message;

    void Start()
    {
        message = "体当たりボール";
    }

     void Update() {}

     void GuiSetup()
     {
        labelStyle = new GUIStyle();
        labelStyle.fontSize = 24;
        labelStyle.normal.textColor = Color.white;
        btnStyle = new GUIStyle(GUI.skin.button);
        btnStyle.fontSize = 24;
        btnStyle.normal.textColor = Color.white;
     }

    void OnGUI()
    {
        GuiSetup();
        GUI.Box (new Rect (10,10,500,200), "Message");
        GUI.Label (new Rect (35,50,700,50), 
            message, labelStyle);
        if (GUI.Button(new Rect (150,120,200,50),"OK!", btnStyle))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
