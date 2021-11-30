using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    public GameObject tap;//����ꏊ

    private GameObject gameManager;
    private bool judgeOnOff;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgeOnOff = true;
    }

    // Update is called once per frame
    void Update()
    {    
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//�m�[�c�̈ړ�
    }

    void OnTriggerEnter2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������
    {
        
        if (coll.CompareTag("PERFECT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(1);
            gameManager.GetComponent<GameManager>().ComboAdd();
            judgeOnOff = false;

            //break;

        }
        else if (coll.CompareTag("GREAT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(2);
            gameManager.GetComponent<GameManager>().ComboAdd();
            //break;
            judgeOnOff = false;

        }
        else if (coll.CompareTag("GOOD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(3);
            gameManager.GetComponent<GameManager>().ComboAdd();
            //break;
            judgeOnOff = false;

        }
        else if (coll.CompareTag("BAD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(4);
            gameManager.GetComponent<GameManager>().ComboKill();
            //break;
            judgeOnOff = false;

        }


        if (coll.CompareTag("Delete"))//�W���b�W�G���A����O�ꂽ��
        {
            gameManager.GetComponent<GameManager>().judgeKind(5);
            gameManager.GetComponent<GameManager>().ComboKill();

        }
        Destroy(gameObject);

    }
}
//�m�[�c�P�ɕt����ׂ�����
/*
 * �m�[�c���ꂼ��ɃL�[���͂̎�ނ���������
 * 
 �L�[���������m�[�c�Ɣ���̈ʒu����遨���育�Ƃ̏���������
 �L�[���������u�Ԃɔ���Active�ɂ��āA���ɂȂ��Ƃ��͔�A�N�e�B�u�ł悫�H���������ςȂ�NG�ɂ�����
 */