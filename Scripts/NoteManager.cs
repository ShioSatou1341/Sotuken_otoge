using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NoteManager : MonoBehaviour
{
    public GameObject notePrefab;
    bool noteInstNow;//ノーツの生成数
    // Start is called before the first frame update
    void Start()
    {
        noteInstNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        //フレームの猶予を設けて、その間に1こノーツを生成する
        if (Time.frameCount % 10 == 0 && noteInstNow == true)
        {
            noteInstNow = false;
            SpawnNote();

        }

        if (noteInstNow == false)
        {
            if (Time.frameCount % 10 == 0)
            {
                noteInstNow = true;
            }

        }



    }

    public void SpawnNote()
    {
        Instantiate(notePrefab, new Vector3(0, 10, 0), Quaternion.identity);//ノーツ生成
        

    }
}
//ノーツ生成修正すべきこと
//・1フレーム単位での生成だと処理落ちしたときに抜けちゃう
//10フレームに1回の範囲で生成したけどやっぱある程度抜けるね…
//同時に複数のノーツも作りたいよね

