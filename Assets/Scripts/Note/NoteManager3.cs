using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NoteManager3 : MonoBehaviour
{
    public GameObject notePrefab;
    public GameObject healPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNote()//TLでマーカーを置くことでそのタイミングで生成できる
    {
        Instantiate(notePrefab, new Vector3(5, 10, 0), Quaternion.identity);//ノーツ生成s

    }
    public void SpawnHeal()//TLでマーカーを置くことでそのタイミングで生成できる
    {
        Instantiate(healPrefab, new Vector3(5, 10, 0), Quaternion.identity);//ノーツ生成s

    }
}