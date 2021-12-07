using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    public AudioClip tap;//�^�b�v��
    private AudioSource audioSource;

    //public GameObject nortPrefab;
    public GameObject judgePrefab_Right;
    public GameObject judgePrefab_Center;
    public GameObject judgePrefab_Left;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PushEfect(0);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PushEfect(1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PushEfect(2);
        }

    }

    void PushEfect(int pushNo)//�{�^���������ꂽ��
    {
        //float bfTime = Time.realtimeSinceStartup;
        audioSource.PlayOneShot(tap);

        switch (pushNo)
        {
            case 0:
                Instantiate(judgePrefab_Left, new Vector3(0, 0, 0), Quaternion.identity);//���萶��
                //Destroy(judgePrefab_Left, 0.2f);
                break;
            case 1:
                Instantiate(judgePrefab_Center, new Vector3(0, 0, 0), Quaternion.identity);//���萶��
                //Destroy(judgePrefab_Center, 0.2f);
                break;
            case 2:
                Instantiate(judgePrefab_Right, new Vector3(0, 0, 0), Quaternion.identity);//���萶��
                //Destroy(judgePrefab_Right, 0.2f);
                break;
        }


        Debug.Log("������");

        //�������Ƃ��͂��̈��̂ݔ������Ă邩����v
    }


}
