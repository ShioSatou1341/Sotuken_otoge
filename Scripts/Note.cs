using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    public GameObject tap;//����ꏊ

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {    
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//�m�[�c�̈ړ�
    }

    void OnTriggerStay2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������B�ʏ�͔�A�N�e�B�u
    {
        if (coll.CompareTag("PERFECT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(1);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboAdd();

        }
        else if (coll.CompareTag("GREAT"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(2);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboAdd();

        }
        else if (coll.CompareTag("GOOD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(3);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboAdd();

        }
        else if (coll.CompareTag("BAD"))
        {
            gameManager.GetComponent<GameManager>().judgeKind(4);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboKill();

        }


        if (coll.CompareTag("Delete"))//�W���b�W�G���A����O�ꂽ��
        {
            gameManager.GetComponent<GameManager>().judgeKind(5);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().ComboKill();

        }
    }
}
//�m�[�c�P�ɕt����ׂ�����
/*
 * �m�[�c���ꂼ��ɃL�[���͂̎�ނ���������
 * 
 �L�[���������m�[�c�Ɣ���̈ʒu����遨���育�Ƃ̏���������
 �L�[���������u�Ԃɔ���Active�ɂ��āA���ɂȂ��Ƃ��͔�A�N�e�B�u�ł悫�H���悫���ۂ��I�I�I
 */