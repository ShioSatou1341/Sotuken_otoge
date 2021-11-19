using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NoteManager : MonoBehaviour
{
    public GameObject notePrefab;
    bool noteInstNow;//�m�[�c�̐�����
    // Start is called before the first frame update
    void Start()
    {
        noteInstNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�t���[���̗P�\��݂��āA���̊Ԃ�1���m�[�c�𐶐�����
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
        Instantiate(notePrefab, new Vector3(0, 10, 0), Quaternion.identity);//�m�[�c����
        

    }
}
//�m�[�c�����C�����ׂ�����
//�E1�t���[���P�ʂł̐������Ə������������Ƃ��ɔ������Ⴄ
//10�t���[����1��͈̔͂Ő����������ǂ���ς�����x������ˁc
//�����ɕ����̃m�[�c����肽�����

