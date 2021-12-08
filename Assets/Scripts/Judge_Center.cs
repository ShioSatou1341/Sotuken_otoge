using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_Center : MonoBehaviour
{
    private GameObject gameManager;
    //private bool OnOff;
    private int i;
    //[SerializeField] float radius;
    //private float distance;
    //public RaycastHit2D hit;
    // Start is called before the frst frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1秒で消す
        gameManager = GameObject.Find("GameManager");
        //Debug.Log("Perfect判定生成");
        //OnOff = true;
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }


    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    Destroy(gameObject);//ノーツがぶつかったら消す

    //}//後で判定出来たら消すに変更したい

    void OnTriggerExit2D(Collider2D coll)
    {
        //左から流れたものだけ対応させる
        //指定した1方向から流れるノーツに対応させる
        //ノーツprefabにタグ付けしよう
        if (coll.CompareTag("Note_Down"))
        {
            Destroy(gameObject); //消す
            Destroy(coll.gameObject); //消す

            if (i == 1)
            {
                gameManager.GetComponent<GameManager>().ComboAdd();
                gameManager.GetComponent<GameManager>().judgeKind(1);//perfect

                Debug.Log("判定Delete" + i);
                i++;
            }

        }
    }
}
//その他good,greatは別で作ってエリアごとにはっ付けた
//→判定はよくなったけどやっぱりコンボが無駄に増える
