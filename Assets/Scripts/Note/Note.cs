using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    private GameObject gameManager;
    private GameObject judgePrefab;
    private bool judgeOnOff;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        judgeOnOff = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//ノーツの移動
    }


    void OnTriggerEnter2D(Collider2D coll)//判定はキーを押したときのみ表示される
    {
        //if (coll.CompareTag("JudgeCenter"))
        //{
            while (judgeOnOff)
            {

                if (coll.CompareTag("PERFECT"))//ジャッジエリアから外れたら
                {
                    gameManager.GetComponent<GameManager>().judgeKind(1);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;
                }
                else if (coll.CompareTag("GREAT"))//ジャッジエリアから外れたら
                {
                    gameManager.GetComponent<GameManager>().judgeKind(2);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                else if (coll.CompareTag("GOOD"))//ジャッジエリアから外れたら
                {
                    gameManager.GetComponent<GameManager>().judgeKind(3);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                else if (coll.CompareTag("BAD"))//ジャッジエリアから外れたら
                {
                    gameManager.GetComponent<GameManager>().judgeKind(4);
                    gameManager.GetComponent<GameManager>().ComboKill();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                
                else if (coll.CompareTag("Delete"))//ジャッジエリアから外れたら
                {
                    gameManager.GetComponent<GameManager>().judgeKind(5);
                    gameManager.GetComponent<GameManager>().ComboKill();
                    Destroy(gameObject);
                    judgeOnOff = false;
                }
                else
                {
                    break;
                }

            }
        //}



    }

}
//ノーツ１つに付けるべきもの
/*
 * ノーツそれぞれにキー入力の種類を持たせる
 * 
 キーを押す→ノーツと判定の位置を取る→判定ごとの処理をする
 */