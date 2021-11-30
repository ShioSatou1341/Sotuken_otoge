using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    public AudioClip tap;//タップ音
    private AudioSource audioSource;

    public GameObject[] tapImage = new GameObject[3];
    private bool[] pushImg = new bool[3];
    private bool[] judgeFlg = new bool[3];

    public GameObject nortPrefab;
    public GameObject judgePrefab;




    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        //ボタンの白画像表示
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

        if (Input.GetKeyUp(KeyCode.LeftArrow))//キーを離した時
        {
            KeyUpEfect(0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))//キーを離した時
        {
            KeyUpEfect(1);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))//キーを離した時
        {
            KeyUpEfect(2);
        }
        //All ifなのは、同時押しや押しっぱなしとかに対応できる


        tapImage[0].SetActive(pushImg[0]);
        tapImage[1].SetActive(pushImg[1]);
        tapImage[2].SetActive(pushImg[2]);

    }

    void PushEfect(int pushNo)//ボタンが押された時
    {
        float bfTime = Time.realtimeSinceStartup;
        audioSource.PlayOneShot(tap);
        pushImg[pushNo] = false;//押されたら白非表示
        switch (pushNo)
        {
            case 0:
                Instantiate(judgePrefab, new Vector3(-5, 0, 0), Quaternion.identity);//判定生成
                break;
            case 1:
                Instantiate(judgePrefab, new Vector3(0, 0, 0), Quaternion.identity);//判定生成
                break;
            case 2:
                Instantiate(judgePrefab, new Vector3(5, 0, 0), Quaternion.identity);//判定生成
                break;
        }
        
        Debug.Log("押した");

        //押したときはその一回のみ反応してるから大丈夫
    }
    void KeyUpEfect(int pushNo)//ボタンから離れた時
    {
        pushImg[pushNo] = true;
    }

}
