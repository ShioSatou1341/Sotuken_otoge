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
    private Vector2 rayPos;//raycast2dを飛ばす位置



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        judgeOnOff = false;//はじめはオフにしたい
        Application.targetFrameRate = 60; //FPSを60に設定 
        rayPos = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//ノーツの移動
        rayPos = gameObject.transform.position;
        rayPos.y -= 0.1f;//y位置をずらす

        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.down, 1.0f);//ノーツから下向きに距離1以内にいるか探す
        Debug.DrawRay(rayPos, Vector2.down * 1.0f, Color.red, 0.1f, false);//デバッグ用
        if (hit.collider)//何かあたって、
        {
            if (hit.collider.gameObject.CompareTag("Note_Down"))//それがNote_Downタグならば
            {
                judgeOnOff = false;//まだ判定しない
                //Debug.Log(gameObject.name + "の前に" + hit.collider.gameObject.name + "がいる");
            }

        }
        else//いなければ
        {
            judgeOnOff = true;//判定可能
            //Debug.Log("先頭" + gameObject.name);

        }

    }


    void OnTriggerEnter2D(Collider2D coll)//判定はキーを押したときのみ表示される
    {
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

    }

}
//ノーツ１つに付けるべきもの
/*
 * なぜか赤ノーツのみコンボ2つ増えてまう。
 * 他の左右からのノーツはコンボは1つずつ増えるのにね
 */