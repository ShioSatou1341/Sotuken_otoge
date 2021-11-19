using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    public GameObject tap;//判定場所

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {    
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//ノーツの移動
    }

    void OnTriggerStay2D(Collider2D coll)//判定はキーを押したときのみ表示される。通常は非アクティブ
    {
        if (coll.CompareTag("PERFECT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(1);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboAdd();

        }
        else if (coll.CompareTag("GREAT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(2);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboAdd();

        }
        else if (coll.CompareTag("GOOD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(3);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboAdd();

        }
        else if (coll.CompareTag("BAD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(4);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboKill();

        }


        if (coll.CompareTag("Delete"))//ジャッジエリアから外れたら
        {
            gameManager.GetComponent<GameManager>().judgeKind(5);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboKill();

        }
    }
}
//ノーツ１つに付けるべきもの
/*
 * ノーツそれぞれにキー入力の種類を持たせる
 * 
 キーを押す→ノーツと判定の位置を取る→判定ごとの処理をする
 キーを押した瞬間に判定Activeにして、特にないときは非アクティブでよき？→よきっぽい！！！
 */