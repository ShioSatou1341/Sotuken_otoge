using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_right : MonoBehaviour
{
    private GameObject gameManager;
    private int i;
    // Start is called before the frst frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1秒で消す
        gameManager = GameObject.Find("GameManager");
        Debug.Log("Right判定生成");
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D coll)
    {

            //左から流れたものだけ対応させる
            //指定した1方向から流れるノーツに対応させる
            //ノーツprefabにタグ付けしよう
            if (coll.gameObject.name == "notePrefab3(Clone)")
            {
                Destroy(gameObject); //消す
                if (i == 1)
                {
                    Debug.Log("判定Delete" + i);
                    i++;
                }

            }
    }
}
//その他good,greatは別で作ってエリアごとにはっ付けた
//→判定はよくなったけどやっぱりコンボが無駄に増える
