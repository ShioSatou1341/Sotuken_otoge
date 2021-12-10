using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Left : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    private GameObject gameManager;
    private GameObject judgePrefab;
    public float moveX;
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
        transform.Translate(-((moveSpeed / moveX) * Time.deltaTime), moveSpeed * Time.deltaTime, 0);//ノーツの移動

    }
    void OnTriggerEnter2D(Collider2D coll)//判定はキーを押したときのみ表示される
    {

        while (judgeOnOff)
        {
            //if (coll.CompareTag("JudgeCenter"))
            //{
            if (coll.CompareTag("PERFECT1"))//ジャッジエリアから外れたら
            {
                gameManager.GetComponent<GameManager>().judgeKind(1);
                gameManager.GetComponent<GameManager>().ComboAdd();
                Destroy(gameObject);
                judgeOnOff = false;
            }
            else if (coll.CompareTag("GREAT1"))//ジャッジエリアから外れたら
            {
                gameManager.GetComponent<GameManager>().judgeKind(2);
                gameManager.GetComponent<GameManager>().ComboAdd();
                Destroy(gameObject);
                judgeOnOff = false;

            }
            else if (coll.CompareTag("GOOD1"))//ジャッジエリアから外れたら
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

            //}

        }




    }


}
//ノーツ１つに付けるべきもの
/*
 * ノーツそれぞれにキー入力の種類を持たせる
 * 
 キーを押す→ノーツと判定の位置を取る→判定ごとの処理をする
 */