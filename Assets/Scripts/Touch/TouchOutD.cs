using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOutD : MonoBehaviour
{
    Vector3 cv = new Vector3(0f, 1f, -5f);
    Rigidbody rb = null;
    Dictionary<string, int> data = new Dictionary<string, int>(); // データ辞書
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var obs = GameObject.FindGameObjectsWithTag("Other");
        foreach (var ob in obs)
        {
            data[ob.name] = 0;
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
            data[collider.gameObject.name] += 1;
            ChangeOther(collider.gameObject);
            // SetupOther(); // 全Otherを更新（ここでは使わない）
        }
    }

    // GameObjectの表示を更新
    void ChangeOther(GameObject ob)
    {
        var rd = ob.GetComponent<Renderer>();
        var d = 1.0f - data[ob.name] * 0.1f;
        var c = rd.material.color;
        c.a = d;
        rd.material.color = c;
        rd.material.SetFloat("_Metallic", d);
    }

    // dataをもとにOtherスフィアを更新する
    void SetupOther()
    {
        foreach (var ky in data)
        {
            var ob = GameObject.Find(ky.Key);
            ChangeOther(ob);
        }
    }
}
