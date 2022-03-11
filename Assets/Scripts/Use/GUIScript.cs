using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIScript : MonoBehaviour
{   
   
    int des;
    string des_t;
    public int countProperty // ここでプロパティを使う。publicをつけます。
    {
        get { return des; }  // これがgettr。他のスクリプトから呼び出した時、returnのあとに書いた変数を返す。
        set { des = value; } // これがsettr。valueには他のスクリプトで代入された値が格納されます。（そこまで気にしなくて大丈夫。）
    }

    // Update is called once per frame
    void Update()
    {
        des_t = des.ToString();
        if (des_t == "10"){
            SceneManager.LoadScene("GameCLEAR");
        } 
    }

    void OnGUI()
    {
        GUI.Box (new Rect (10,10,350,100), "Message");
        GUI.Label (new Rect (35,60,300,50), 
            "今、破壊した箱の数は"+ des_t + "個");
    }

}
