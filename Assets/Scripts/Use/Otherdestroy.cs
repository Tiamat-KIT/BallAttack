using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otherdestroy : MonoBehaviour
{    
    bool f = true;
    Vector3 cv = new Vector3(0f, 1f, -5f);
    Rigidbody rb = null;
    //public int D_Item = 0;
    GUIScript GUI;

    void Start()
    {
        Application.targetFrameRate = 45; // 30fpsに設定
        rb = GetComponent<Rigidbody>();
        this.GUI = FindObjectOfType<GUIScript>(); //スクリプトを探して上宣言した変数に代入。
        int i = GUI.countProperty; // スクリプトAから変数を持ってくる。（get）
        //GUI.countProperty = 10; // 取ってきたスクリプトAの変数を変更。（set）        
    }

    void Update()
    {
        var sv = transform.position;
        sv.y = 1f;
        Camera.main.transform.position = sv + cv;

        var x = Input.GetAxis("Horizontal")*12.0f;
        var y = Input.GetAxis("Vertical")*12.0f;
        var v = new Vector3(x, 0, y);
    
        if(Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        rb.AddForce(v); 

        /*var sv = transform.position;
        sv.y = 1f;
        Camera.main.transform.position = sv + cv;

        var mp = Input.mousePosition;
        var x = (int)(mp.x / (Screen.width / 3));
        var y = (int)(mp.y / (Screen.height / 3));
        
        var vx = Vector3.zero;
        var vy = Vector3.zero;
        var vz = Vector3.zero;
        switch(x)
        {
            case 0:
            vx = new Vector3(-1f, 0f, 0f);
            break;
            case 2:
            vx = new Vector3(1f, 0f, 0f);
            break;
        }
        switch(y)
        {
            case 0:
            vy = new Vector3(0f, 0f, -1f);
            break;
            case 2:
            vy = new Vector3(0f, 0f, 1f);
            break;
        }
        if (Input.GetMouseButtonDown(0))
        {
            vz = new Vector3(0f, 1000f, 0f);
        }
        rb.AddForce(vx + vy + vz); */
    }



    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Other")
        {
            GameObject.Destroy(collision.gameObject);
            //D_Item++;
            GUI.countProperty++; 
        }
    }
}
