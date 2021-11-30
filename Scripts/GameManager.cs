using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public GameObject notePrefab;
    //public GameObject Heal;//�񕜃m�[�c
    public int Life;  //Life�\��
    

    private int totalCombo;//���̎��̃R���{��
    private int bestCombo;//�ő��R���{��
    private Text comboText;//�R���{�\��

    private Text judgeText;//����\��

    private Text perfectText;//�p�t�F�m�[�c���e�L�X�g
    private int perfectNote;//�p�t�F����m�[�c�̌�

    private Text greatText;//�p�t�F�m�[�c���e�L�X�g
    private int greatNote;//�O������m�[�c�̌�

    private Text goodText;//�p�t�F�m�[�c���e�L�X�g
    private int goodNote;//�O�b�h����m�[�c�̌�

    private Text badText;//�p�t�F�m�[�c���e�L�X�g
    private int badNote;//�o�b�h����m�[�c�̌�

    private Text missText;//�p�t�F�m�[�c���e�L�X�g
    private int missNote;//�������~�X����m�[�c�̌�

    private Text lifeText;//life�̃e�L�X�g
   

    private bool inGame;//�Q�[�������ۂ�

    private Canvas resultCanvas;//���U���g�L�����o�X
    private Text resultText;//���U���g��ʂŏo���R���{�̃e�L�X�g
    // Start is called before the first frame update
    void Start()
    {
        totalCombo = 0;
        bestCombo = 0;
        resultText = GameObject.Find("comboText").GetComponent<Text>();

        perfectNote = 0;
        greatNote = 0;
        goodNote = 0;
        badNote = 0;
        missNote = 0;
        Life = 10;
        
        judgeText = GameObject.Find("judgeText").GetComponent<Text>();
        comboText = GameObject.Find("Combo").GetComponent<Text>();

        resultCanvas = GameObject.Find("ResultCanvas").GetComponent<Canvas>();
        resultCanvas.enabled = false;//��\��
        perfectText = GameObject.Find("perfectText").GetComponent<Text>();
        greatText = GameObject.Find("greatText").GetComponent<Text>();
        goodText = GameObject.Find("goodText").GetComponent<Text>();
        badText = GameObject.Find("badText").GetComponent<Text>();
        missText = GameObject.Find("missText").GetComponent<Text>();
        lifeText = GameObject.Find("Life").GetComponent<Text>();
        SetlifeText(Life);



        inGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        //int val = int.Parse(comboText.text);
        if (inGame == true)
        {
            if (Input.GetKeyUp(KeyCode.Return))//�m�[�c�����I�������I������ق���������
            {
                inGame = false;

            }
        }
        if (inGame == false)
        {
            resultCanvas.enabled = true;
            resultText.text = (bestCombo).ToString();
            perfectText.text = (PerfectText()).ToString();
            greatText.text = (GreatText()).ToString();
            goodText.text = (GoodText()).ToString();
            badText.text = (BadText()).ToString();
            missText.text = (MissText()).ToString();
            

            if (Input.GetKeyDown(KeyCode.Return))//�Q�[�����I������������xenter�Ŏ��̃V�[��
            {

                SceneManager.LoadScene("ResultScene");
            }
        }



    }
    private void SetlifeText(int Life)
    {
        lifeText.text = "Life:" + Life.ToString();
    }

    public void PushTitle()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ComboAdd()
    {
        totalCombo += 1;
        comboText.text = (totalCombo).ToString();
        Debug.Log(totalCombo + "COMBO");

        if (bestCombo < totalCombo)//�ő��R���{�̋L�^
        {
            bestCombo = totalCombo;
        }
        
    }
    public void ComboKill()
    {
        totalCombo=0;
        comboText.text = (totalCombo).ToString();
        

        //badText.gameObject.SetActive(true);

    }

    public int ComboText()
    {
        return bestCombo;
    }
    public int PerfectText()
    {
        return perfectNote;
    }
    public int GreatText()
    {
        return greatNote;
    }
    public int GoodText()
    {
        return goodNote;
    }
    public int BadText()
    {
        return badNote;
    }
    public int MissText()
    {
        return missNote;
    }

    public void judgeKind(int num)
    {
        switch (num)
        {
            case 1://�p�t�F
                perfectNote++;
                //�񕜃m�[�c�ɂ�����ƂP��
                //if(GameObject.Find("Heal")==true) { Life++;
                //    SetlifeText(Life);
                //}
                judgeText.text = ("PERFECT!");
                Debug.Log("PERFECT");
                break;

            case 2://�O��
                greatNote++;
                //�񕜃m�[�c�ɂ�����ƂP��
                //if (GameObject.Find("Heal") == true)
                //{
                //    Life++;
                //    SetlifeText(Life);
                //}
                judgeText.text = ("GREAT!");
                Debug.Log("GREAT");
                break;
            case 3://�O�h
                goodNote++;
                //�񕜃m�[�c�ɂ�����ƂP��
                //if (GameObject.Find("Heal") == true)
                //{
                //    Life++;
                //    SetlifeText(Life);
                //}
                judgeText.text = ("GOOD");
                Debug.Log("GOOD");
                break;

            case 4:
                badNote++;
                --Life;
                SetlifeText(Life);
                judgeText.text = ("BAD");
                Debug.Log("BAD");
                Debug.Log("-1");

                if (Life==0)//life���O�ɂȂ�����
                {

                    SceneManager.LoadScene("GameOverScene");
                }
                break;

            default:
                missNote++;
                --Life;
                SetlifeText(Life);
                judgeText.text = ("MISS�c");
<<<<<<< HEAD
                Debug.Log("MISS");
                Debug.Log("-1");
                if (Life == 0)//life���O�ɂȂ�����
                {

                    SceneManager.LoadScene("GameOverScene");
                }
               
=======
                //Debug.Log("MISS");
>>>>>>> 7e2aaa04fff9006fdfd950a48574f8fb8d181c55
                break;
        }
        

    }
    /*�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\�\*/


}
//�����ɕK�v�Ȃ���
//�E�X�R�A�v�Z
//�E�i�W���b�W���ƂɎd��������H�j
//�E�Ȃ��I�������V�[���J��
//