using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_gr_Right : MonoBehaviour
{
    private GameObject gameManager;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1�b�ŏ���
        gameManager = GameObject.Find("GameManager");
        Debug.Log("Great���萶��");
        //OnOff = true;
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(gameObject);//�m�[�c���Ԃ����������

    }//��Ŕ���o����������ɕύX������

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Note_Right"))
        {
            Destroy(gameObject); //����
            Destroy(coll.gameObject); //����

            if (i == 1)
            {
                Debug.Log("����Delete" + i);
                gameManager.GetComponent<GameManager>().ComboAdd();
                gameManager.GetComponent<GameManager>().judgeKind(2);


                i++;
            }
        }

    }
}
