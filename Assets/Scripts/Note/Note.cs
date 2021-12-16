using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    private GameObject gameManager;
    private GameObject judgePrefab;
    public bool judgeOnOff;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        judgeOnOff = false;//はじめはオフにしたい

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//ノーツの移動
    }

    public void JudgeSet()
    {
        judgeOnOff = true;
    }

    void noteSerch()//ノーツが自分の前に被っているかどうか探す
    {

    }

    void OnTriggerExit2D(Collider2D coll)//判定はキーを押したときのみ表示される
    {
        //if (coll.CompareTag("JudgeCenter"))
        //{
            while (judgeOnOff==true)
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
 *縦連とかになってるところで近いノーツ一緒に判定始めちゃう
 *ノーツ感覚が【狭いとき】にノーツの距離を図ればよくね？
 *
 *それか、ノーツ自体にY方向に他の同タグノーツがいるかどうか探す
 *→いなければtrueになって普通に判定にうつる
 *→いたらまだ自分はjudgeOnOffはfalseのままにする？とか？
 */