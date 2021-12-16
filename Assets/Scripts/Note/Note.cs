using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    private GameObject gameManager;
    private GameObject judgePrefab;
    public bool judgeOnOff;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        judgeOnOff = false;//�͂��߂̓I�t�ɂ�����

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//�m�[�c�̈ړ�
    }

    public void JudgeSet()
    {
        judgeOnOff = true;
    }

    void noteSerch()//�m�[�c�������̑O�ɔ���Ă��邩�ǂ����T��
    {

    }

    void OnTriggerExit2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������
    {
        //if (coll.CompareTag("JudgeCenter"))
        //{
            while (judgeOnOff==true)
            {

                if (coll.CompareTag("PERFECT"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(1);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;
                }
                else if (coll.CompareTag("GREAT"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(2);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                else if (coll.CompareTag("GOOD"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(3);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                else if (coll.CompareTag("BAD"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(4);
                    gameManager.GetComponent<GameManager>().ComboKill();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                
                else if (coll.CompareTag("Delete"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(5);
                    gameManager.GetComponent<GameManager>().ComboKill();
                    Destroy(gameObject);
                    judgeOnOff = false;
                }
                else
                {
                    break;
                }

            }
        //}



    }

}
//�m�[�c�P�ɕt����ׂ�����
/*
 *�c�A�Ƃ��ɂȂ��Ă�Ƃ���ŋ߂��m�[�c�ꏏ�ɔ���n�߂��Ⴄ
 *�m�[�c���o���y�����Ƃ��z�Ƀm�[�c�̋�����}��΂悭�ˁH
 *
 *���ꂩ�A�m�[�c���̂�Y�����ɑ��̓��^�O�m�[�c�����邩�ǂ����T��
 *�����Ȃ����true�ɂȂ��ĕ��ʂɔ���ɂ���
 *��������܂�������judgeOnOff��false�̂܂܂ɂ���H�Ƃ��H
 */