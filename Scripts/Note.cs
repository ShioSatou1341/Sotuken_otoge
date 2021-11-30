using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    public GameObject tap;//判定場所

    private GameObject gameManager;
    private bool judgeOnOff;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgeOnOff = true;
    }

    // Update is called once per frame
    void Update()
    {    
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//ノーツの移動
    }

    void OnTriggerEnter2D(Collider2D coll)//判定はキーを押したときのみ表示される
    {
        
        if (coll.CompareTag("PERFECT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(1);
            gameManager.GetComponent<GameManager>().ComboAdd();
            judgeOnOff = false;

            //break;

        }
        else if (coll.CompareTag("GREAT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(2);
            gameManager.GetComponent<GameManager>().ComboAdd();
            //break;
            judgeOnOff = false;

        }
        else if (coll.CompareTag("GOOD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(3);
            gameManager.GetComponent<GameManager>().ComboAdd();
            //break;
            judgeOnOff = false;

        }
        else if (coll.CompareTag("BAD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(4);
            gameManager.GetComponent<GameManager>().ComboKill();
            //break;
            judgeOnOff = false;

        }


        if (coll.CompareTag("Delete"))//ジャッジエリアから外れたら
        {
            gameManager.GetComponent<GameManager>().judgeKind(5);
            gameManager.GetComponent<GameManager>().ComboKill();

        }
        Destroy(gameObject);

    }
}
//ノーツ１つに付けるべきもの
/*
 * ノーツそれぞれにキー入力の種類を持たせる
 * 
 キーを押す→ノーツと判定の位置を取る→判定ごとの処理をする
 キーを押した瞬間に判定Activeにして、特にないときは非アクティブでよき？→押しっぱなしNGにさせろ
 */