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
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        judgePrefab = GameObject.Find("Judge");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-((moveSpeed / moveX) * Time.deltaTime), moveSpeed * Time.deltaTime, 0);//�m�[�c�̈ړ�

    }
    void OnTriggerExit2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������
    {

        if (coll.CompareTag("Delete"))//�W���b�W�G���A����O�ꂽ��
        {
            gameManager.GetComponent<GameManager>().judgeKind(5);
            gameManager.GetComponent<GameManager>().ComboKill();
            Destroy(gameObject);
        }


    }

}
//�m�[�c�P�ɕt����ׂ�����
/*
 * �m�[�c���ꂼ��ɃL�[���͂̎�ނ���������
 * 
 �L�[���������m�[�c�Ɣ���̈ʒu����遨���育�Ƃ̏���������
 */