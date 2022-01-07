using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Right : MonoBehaviour
{
    private float moveSpeed = -7.5f;

    private GameObject gameManager;
    private GameObject judgePrefab;
    public float moveX;
    private bool judgeOnOff;
    private Vector2 rayPos;//raycast2d���΂��ʒu

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        judgeOnOff = false;
        rayPos = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(((moveSpeed / moveX) * Time.deltaTime), moveSpeed * Time.deltaTime, 0);//�m�[�c�̈ړ�
        rayPos = gameObject.transform.position;
        rayPos.y -= 0.1f;//y�ʒu�����炷

        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.down, 1.0f);//�m�[�c���牺�����ɋ���1�ȓ��ɂ��邩�T��
        Debug.DrawRay(rayPos, Vector2.down * 1.0f, Color.red, 0.1f, false);//�f�o�b�O�p
        if (hit.collider)//�����������āA
        {
            if (hit.collider.gameObject.CompareTag("Note_Right"))//���ꂪNote_Right�^�O�Ȃ��
            {
                judgeOnOff = false;//�܂����肵�Ȃ�
                Debug.Log(gameObject.name + "�̑O��" + hit.collider.gameObject.name + "������");
            }

        }
        else//���Ȃ����
        {
            judgeOnOff = true;//����\
            Debug.Log("�擪" + gameObject.name);

        }

    }
    void OnTriggerExit2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������
    {

        while (judgeOnOff)
        {
            //if (coll.CompareTag("JudgeRight"))
            //{
                if (coll.CompareTag("PERFECT2"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(1);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;
                }
                else if (coll.CompareTag("GREAT2"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(2);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                else if (coll.CompareTag("GOOD2"))//�W���b�W�G���A����O�ꂽ��
                {
                    gameManager.GetComponent<GameManager>().judgeKind(3);
                    gameManager.GetComponent<GameManager>().ComboAdd();
                    Destroy(gameObject);
                    judgeOnOff = false;

                }
                else if (coll.CompareTag("BAD2"))//�W���b�W�G���A����O�ꂽ��
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