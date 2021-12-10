using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NoteManager2 : MonoBehaviour
{
    public GameObject notePrefab;
    bool noteInstNow;//ノーツが作れるかどうか

    private int cnt;
    //private int note_cnt;//ノーツ総数
    // Start is called before the first frame update
    void Start()
    {
        noteInstNow = true;
        cnt = 0;
        //note_cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0 /*&& noteInstNow == true*/)
        {
            Instantiate(notePrefab, new Vector3(-5, 10, 0), Quaternion.identity);//ノーツ生成s
            Debug.Log("SpawnNote");
            noteInstNow = false;
        }

    }

}
//ノーツ生成修正すべきこと
//・1フレーム単位での生成だと処理落ちしたときに抜けちゃう
//10フレームに1回の範囲で生成したけどやっぱある程度抜けるね…


