using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1�b�ŏ���

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)//����̓L�[���������Ƃ��̂ݕ\�������B�ʏ�͔�A�N�e�B�u
    {
        Destroy(gameObject, 0);
    }
}
