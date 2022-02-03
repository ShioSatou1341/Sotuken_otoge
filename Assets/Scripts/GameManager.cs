using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static int sp = 0;//�X�R�A
    //public GameObject Heal;//�񕜃m�[�c
    public int Life;  //Life�\��
    private int Score;//�X�R�A

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

    private Text scoreText;//score�̃e�L�X�g

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
        //Life = 10;
        Score = 0;

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
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        SetlifeText();
        SetscoreText(Score);

        PlayerPrefs.SetString("Play", SceneManager.GetActiveScene().name);//���������Ă镈�ʂ̃V�[�����擾
        PlayerPrefs.Save();
        

        inGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        //int val = int.Parse(comboText.text);
        //if (inGame == true)
        //{
        //    if (Input.GetKeyUp(KeyCode.Return))//�m�[�c�����I�������I������ق���������
        //    {
        //        inGame = false;

        //    }
        //}
        //if (inGame == false)
        //{
        //   SceneManager.LoadScene("ResultScene2");
        //}

    }

    public void Result()
    {
        SceneManager.LoadScene("ResultScene2");

    }
    public void PushTitle()
    {
        SceneManager.LoadScene("StartScene");
    }
    private void SetlifeText(/*int Life*/)
    {
        lifeText.text = "Life:" + Life.ToString();
    }
    private void SetscoreText(int Score)
    {
        scoreText.text = "Score:" + Score.ToString();
    }
    public void ResultScore()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        Debug.Log("save" + Score);
    }
    public void ScoreAdd()
    {
        sp = Score;
        Debug.Log(sp + ":result");
    }
    public void ComboAdd()
    {
        totalCombo += 1;
        comboText.text = (totalCombo).ToString();
        Debug.Log(totalCombo + "COMBO");

        if (bestCombo < totalCombo)//�ő��R���{�̋L�^
        {
            bestCombo = totalCombo;
            PlayerPrefs.SetInt("MaxCombo", bestCombo);
            PlayerPrefs.Save();
        }


    }
    public void ComboKill()
    {
        totalCombo=0;
        comboText.text = (totalCombo).ToString();

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

    public void LifeAdd()
    {
        if (Life < 10)//Life���10�Ƃ���
        {
            Life += 1;
            SetlifeText();
        }

    }

    public void judgeKind(int num)
    {
        switch (num)
        {
            case 1://�p�t�F
                perfectNote++;
                PlayerPrefs.SetInt("Perfect", perfectNote);
                PlayerPrefs.Save();
                SetlifeText();
                Score += 50;
                ScoreAdd();
                SetscoreText(Score);
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.Save();
                Debug.Log("save" + Score);
                Debug.Log(PlayerPrefs.GetInt("Score", 0));
                judgeText.text = ("PERFECT!");
                Debug.Log("PERFECT");
                break;

            case 2://�O��
                //ComboAdd();
                greatNote++;
                PlayerPrefs.SetInt("Great", greatNote);
                PlayerPrefs.Save();
                //�񕜃m�[�c�ɂ�����ƂP��
                //if (GameObject.Find("Heal") == true)
                //{
                //    Life++;
                SetlifeText();
                //}
                Score += 30;
                ScoreAdd();
                SetscoreText(Score);
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.Save();
                Debug.Log("save" + Score);
                Debug.Log(PlayerPrefs.GetInt("Score", 0));
                judgeText.text = ("GREAT!");
                Debug.Log("GREAT");
                break;
            case 3://�O�h
                //ComboAdd();
                goodNote++;
                PlayerPrefs.SetInt("Good", goodNote);
                PlayerPrefs.Save();
                //�񕜃m�[�c�ɂ�����ƂP��
                //if (GameObject.Find("Heal") == true)
                //{
                //    Life++;
                SetlifeText();
                //}
                Score += 10;
                ScoreAdd();
                SetscoreText(Score);
                Debug.Log("save" + Score);
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.GetInt("Score", 0));
                judgeText.text = ("GOOD");
                Debug.Log("GOOD");
                break;

            case 4:
                ComboKill();
                badNote++;
                PlayerPrefs.SetInt("Bad", badNote);
                PlayerPrefs.Save();
                --Life;
                SetlifeText();
                judgeText.text = ("BAD");
                Debug.Log("BAD");

                if (Life == 0)//life���O�ɂȂ�����
                {

                    SceneManager.LoadScene("GameOverScene");
                }
                break;

            default:
                ComboKill();
                --Life;
                SetlifeText();
                missNote++;
                PlayerPrefs.SetInt("Miss", missNote);
                PlayerPrefs.Save();
                judgeText.text = ("MISS�c");
                //Debug.Log("MISS");
                if (Life == 0)//life���O�ɂȂ�����
                {

                    SceneManager.LoadScene("GameOverScene");
                }
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