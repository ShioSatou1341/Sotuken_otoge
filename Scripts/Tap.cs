using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    public AudioClip tap;//�^�b�v��
    private AudioSource audioSource;

    public GameObject[] tapImage = new GameObject[3];
    public GameObject[] judgeImage = new GameObject[3];
    private bool[] pushImg = new bool[3];

    public GameObject nortPrefab;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        //�{�^���̔��摜�\��
        pushImg[0]= true;
        pushImg[1] = true;
        pushImg[2] = true;
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

        if (Input.GetKeyUp(KeyCode.LeftArrow))//�L�[�𗣂�����
        {
            KeyUpEfect(0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))//�L�[�𗣂�����
        {
            KeyUpEfect(1);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))//�L�[�𗣂�����
        {
            KeyUpEfect(2);
        }
        //All if�Ȃ̂́A���������≟�����ςȂ��Ƃ��ɑΉ��ł���


        tapImage[0].SetActive(pushImg[0]);
        tapImage[1].SetActive(pushImg[1]);
        tapImage[2].SetActive(pushImg[2]);

        judgeImage[0].SetActive(!pushImg[0]);//�����Ă遁false�����炻�̔���true�ŃA�N�e�B�u�ɂ���
        judgeImage[1].SetActive(!pushImg[1]);
        judgeImage[2].SetActive(!pushImg[2]);

    }

    void PushEfect(int pushNo)//�{�^���������ꂽ��
    {
        audioSource.PlayOneShot(tap);
        pushImg[pushNo] = false;//�����ꂽ�甒��\��
    }
    void KeyUpEfect(int pushNo)//�{�^�����痣�ꂽ��
    {
        pushImg[pushNo] = true;
    }



}
