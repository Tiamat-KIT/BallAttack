using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchout : MonoBehaviour
{
    Vector3 cv = new Vector3(0f, 1f, -5f);
    Rigidbody rb = null;
    int[] data = {}; // データ保管用の配列
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var obs = GameObject.FindGameObjectsWithTag("Other");
        // 配列dataの初期化処理
        data = new int[obs.Length];
        for (var i = 0;i < obs.Length;i++)
        {
            data[i] = 0;
        }
    }

    void Update()
    {
        var sv = transform.position;
        sv.y = 1f;
        Camera.main.transform.position = sv + cv;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var v = new Vector3(x, 0, y);
        rb.AddForce(v);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Other")
        {
            // 触れたOtherに対応する配列の値を１増やす
            var n = int.Parse(collider.gameObject.name.Substring(5));
            data[n] += 1;
            SetupOther();
        }
    }

    // Otherスフィアの色の透過度とメタリックを再設定する
    void SetupOther()
    {
        for (int i = 0;i < data.Length;i++)
        {
            var ob = GameObject.Find("Cube " + i);
            var rd = ob.GetComponent<Renderer>();
            var d = 1.0f - data[i] * 0.1f;
            var c = rd.material.color;
            c.a = d;
            rd.material.color = c;
            rd.material.SetFloat("_Metallic", d);
        }
    }
}
