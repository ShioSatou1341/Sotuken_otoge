using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_Center : MonoBehaviour
{
    private GameObject gameManager;
    //private bool OnOff;
    private int i;
    //[SerializeField] float radius;
    //private float distance;
    //public RaycastHit2D hit;
    // Start is called before the frst frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1�b�ŏ���
        gameManager = GameObject.Find("GameManager");
        //Debug.Log("Perfect���萶��");
        //OnOff = true;
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }


    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    Destroy(gameObject);//�m�[�c���Ԃ����������

    //}//��Ŕ���o����������ɕύX������

    void OnTriggerExit2D(Collider2D coll)
    {
        //�����痬�ꂽ���̂����Ή�������
        //�w�肵��1�������痬���m�[�c�ɑΉ�������
        //�m�[�cprefab�Ƀ^�O�t�����悤
        if (coll.CompareTag("Note_Down"))
        {
            Destroy(gameObject); //����
            Destroy(coll.gameObject); //����

            if (i == 1)
            {
                gameManager.GetComponent<GameManager>().ComboAdd();
                gameManager.GetComponent<GameManager>().judgeKind(1);//perfect

                Debug.Log("����Delete" + i);
                i++;
            }

        }
    }
}
//���̑�good,great�͕ʂō���ăG���A���Ƃɂ͂��t����
//������͂悭�Ȃ������ǂ���ς�R���{�����ʂɑ�����
