using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_right : MonoBehaviour
{
    private GameObject gameManager;
    private int i;
    // Start is called before the frst frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1�b�ŏ���
        gameManager = GameObject.Find("GameManager");
        Debug.Log("Right���萶��");
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D coll)
    {

            //�����痬�ꂽ���̂����Ή�������
            //�w�肵��1�������痬���m�[�c�ɑΉ�������
            //�m�[�cprefab�Ƀ^�O�t�����悤
            if (coll.gameObject.name == "notePrefab3(Clone)")
            {
                Destroy(gameObject); //����
                if (i == 1)
                {
                    Debug.Log("����Delete" + i);
                    i++;
                }

            }
    }
}
//���̑�good,great�͕ʂō���ăG���A���Ƃɂ͂��t����
//������͂悭�Ȃ������ǂ���ς�R���{�����ʂɑ�����
