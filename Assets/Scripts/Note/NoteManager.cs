using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NoteManager : MonoBehaviour
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

        //SpawnNote();

        if (Time.frameCount % 30 == 0 /*&& noteInstNow == true*/)//updateが60回/秒で動くからその半分の早さで処理させる
        {
            Instantiate(notePrefab, new Vector3(0, 10, 0), Quaternion.identity);//ノーツ生成s
            Debug.Log("SpawnNote");
            noteInstNow = false;
        }//まだ抜けができるし、判定自体もダメ。でもこれで生成自体は幾分マシになった
    }

    public void SpawnNote()
    {

        
        //if (noteInstNow == true)
        //{
        //    Instantiate(notePrefab, new Vector3(0, 10, 0), Quaternion.identity);//ノーツ生成s
        //    cnt++;
        //    //note_cnt++;
        //    Debug.Log("SpawnNote");
        //}


        //if (cnt > 0)
        //{
        //    noteInstNow = false;
        //    cnt++;
        //}
        //if (Time.frameCount % 12 == 0)
        //{
        //    cnt = 0;
        //    noteInstNow = true;
        //}

    }
}
//ノーツ生成修正すべきこと
//・1フレーム単位での生成だと処理落ちしたときに抜けちゃう
//でも2フレームとるなりすると重複する