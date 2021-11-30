using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1秒で消す

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)//判定はキーを押したときのみ表示される。通常は非アクティブ
    {
        Destroy(gameObject, 0);
    }
}
