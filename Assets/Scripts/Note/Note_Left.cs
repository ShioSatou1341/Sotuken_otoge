using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Left : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    private GameObject gameManager;
    private GameObject judgePrefab;
    public float moveX;
    private bool judgeOnOff;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        judgeOnOff = true;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-((moveSpeed / moveX) * Time.deltaTime), moveSpeed * Time.deltaTime, 0);//�m�[�c�̈ړ�

    }
    void OnTriggerEnter2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������
    {

        while (judgeOnOff)
        {
            //if (coll.CompareTag("JudgeCenter"))
            //{
            if (coll.CompareTag("PERFECT1"))//�W���b�W�G���A����O�ꂽ��
            {
                gameManager.GetComponent<GameManager>().judgeKind(1);
                gameManager.GetComponent<GameManager>().ComboAdd();
                Destroy(gameObject);
                judgeOnOff = false;
            }
            else if (coll.CompareTag("GREAT1"))//�W���b�W�G���A����O�ꂽ��
            {
                gameManager.GetComponent<GameManager>().judgeKind(2);
                gameManager.GetComponent<GameManager>().ComboAdd();
                Destroy(gameObject);
                judgeOnOff = false;

            }
            else if (coll.CompareTag("GOOD1"))//�W���b�W�G���A����O�ꂽ��
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

            //}

        }




    }


}
//�m�[�c�P�ɕt����ׂ�����
/*
 * �m�[�c���ꂼ��ɃL�[���͂̎�ނ���������
 * 
 �L�[���������m�[�c�Ɣ���̈ʒu����遨���育�Ƃ̏���������
 */