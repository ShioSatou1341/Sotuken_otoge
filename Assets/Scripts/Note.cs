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

        if (coll.gameObject.tag == "PERFECT")
        {
            //gameManager.GetComponent<GameManager>().ComboAdd();


            ////StartCoroutine("JudgePerfect");
            //gameManager.GetComponent<GameManager>().judgeKind(1);

            Destroy(gameObject);

        }


        //else if (coll.gameObject.tag == "GREAT")
        //{
        //    gameManager.GetComponent<GameManager>().judgeKind(2);
        //    //gameManager.GetComponent<GameManager>().ComboAdd();
        //    ////break;
        //    //judgeOnOff = false;
        //    Destroy(gameObject);
        //    //WaitForSeconds(0.1f);
        //    //StartCoroutine("JudgeGREAT");

        //}
        //else if (coll.gameObject.tag == "GOOD")
        //{
        //    gameManager.GetComponent<GameManager>().judgeKind(3);
        //    //gameManager.GetComponent<GameManager>().ComboAdd();
        //    ////break;
        //    //judgeOnOff = false;
        //    Destroy(gameObject);
        //    //WaitForSeconds(0.1f);
        //    //StartCoroutine("JudgeGOOD");

        //}
        //else if (coll.gameObject.tag == "BAD")
        //{
        //    gameManager.GetComponent<GameManager>().judgeKind(4);
        //    gameManager.GetComponent<GameManager>().ComboKill();
        //    ////break;
        //    //judgeOnOff = false;
        //    Destroy(gameObject);
        //    //WaitForSeconds(0.1f);
        //    //StartCoroutine("JudgeBAD");

        //}


        if (coll.CompareTag("Delete"))//�W���b�W�G���A����O�ꂽ��
        {
            gameManager.GetComponent<GameManager>().judgeKind(5);
            gameManager.GetComponent<GameManager>().ComboKill();
            Destroy(gameObject);
        }


    }

    IEnumerator JudgePerfect()
    {
        for(int i = 0; i > 5; i++)
        {
            judgeOnOff = false;
            yield return new WaitForSeconds(0.1f);

        }
        //Destroy(gameObject);
        yield break;
    }
}
//�m�[�c�P�ɕt����ׂ�����
/*
 * �m�[�c���ꂼ��ɃL�[���͂̎�ނ���������
 * 
 �L�[���������m�[�c�Ɣ���̈ʒu����遨���育�Ƃ̏���������
 */