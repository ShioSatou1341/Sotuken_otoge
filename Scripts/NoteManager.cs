using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NoteManager : MonoBehaviour
{
    public GameObject notePrefab;
    bool noteInstNow;//�m�[�c�����邩�ǂ���

    private int cnt;
    private int note_cnt;//�m�[�c����
    // Start is called before the first frame update
    void Start()
    {
        noteInstNow = true;
        cnt = 0;
        note_cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount%12==0&& noteInstNow == true)
        {
            SpawnNote();
        }
        
    }

    public void SpawnNote()
    {

        if (noteInstNow == true)
        {
            Instantiate(notePrefab, new Vector3(0, 10, 0), Quaternion.identity);//�m�[�c����s
            cnt++;
            note_cnt++;
        }


        if (cnt > 0)
        {
            noteInstNow = false;
            cnt++;
        }
        if (Time.frameCount % 12 == 0)
        {
            cnt = 0;
            noteInstNow = true;
        }

    }
}
//�m�[�c�����C�����ׂ�����
//�E1�t���[���P�ʂł̐������Ə������������Ƃ��ɔ������Ⴄ