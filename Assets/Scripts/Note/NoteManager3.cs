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

    public void SpawnNote()//TL�Ń}�[�J�[��u�����Ƃł��̃^�C�~���O�Ő����ł���
    {
        Instantiate(notePrefab, new Vector3(5, 10, 0), Quaternion.identity);//�m�[�c����s

    }
    public void SpawnHeal()//TL�Ń}�[�J�[��u�����Ƃł��̃^�C�~���O�Ő����ł���
    {
        Instantiate(healPrefab, new Vector3(5, 10, 0), Quaternion.identity);//�m�[�c����s

    }
}