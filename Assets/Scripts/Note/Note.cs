using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    private GameObject gameManager;
    private GameObject judgePrefab;
    private bool judgeOnOff;
    private Vector2 rayPos;//raycast2d���΂��ʒu



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        judgeOnOff = false;//�͂��߂̓I�t�ɂ�����
        Application.targetFrameRate = 60; //FPS��60�ɐݒ� 
        rayPos = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);//�m�[�c�̈ړ�
        rayPos = gameObject.transform.position;
        rayPos.y -= 0.1f;//y�ʒu�����炷

        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.down, 1.0f);//�m�[�c���牺�����ɋ���1�ȓ��ɂ��邩�T��
        Debug.DrawRay(rayPos, Vector2.down * 1.0f, Color.red, 0.1f, false);//�f�o�b�O�p
        if (hit.collider)//�����������āA
        {
            if (hit.collider.gameObject.CompareTag("Note_Down"))//���ꂪNote_Down�^�O�Ȃ��
            {
                judgeOnOff = false;//�܂����肵�Ȃ�
                //Debug.Log(gameObject.name + "�̑O��" + hit.collider.gameObject.name + "������");
            }

        }
        else//���Ȃ����
        {
            judgeOnOff = true;//����\
            //Debug.Log("�擪" + gameObject.name);

        }

    }


    void OnTriggerEnter2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������
    {
        while (judgeOnOff)
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

    }

}
//�m�[�c�P�ɕt����ׂ�����
/*
 * �Ȃ����ԃm�[�c�̂݃R���{2�����Ă܂��B
 * ���̍��E����̃m�[�c�̓R���{��1��������̂ɂ�
 */