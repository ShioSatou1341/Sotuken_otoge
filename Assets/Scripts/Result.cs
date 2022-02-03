using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    //private int ResultScore;
    private Text ResultText;
    private Text PerfecrScore;
    private Text GreatScore;
    private Text GoodScore;
    private Text BadScore;
    private Text Missscore;
    private Text MaxScore;

    private int Score;
    private int Perfect;
    private int Great;
    private int Good;
    private int Bad;
    private int Miss;
    private int MaxCombo;

    // Start is called before the first frame update
    void Start()
    {
        //ResultText = GameObject.Find("ResultText").GetComponent<Text>();  //��
        ResultText = GameObject.Find("ScoreText").GetComponent<Text>();//2�̕�
        PerfecrScore = GameObject.Find("PerfecrScore").GetComponent<Text>();//2�̕�
        GreatScore = GameObject.Find("GreatScore").GetComponent<Text>();//2�̕�
        GoodScore = GameObject.Find("GoodScore").GetComponent<Text>();//2�̕�
        BadScore = GameObject.Find("BadScore").GetComponent<Text>();//2�̕�
        Missscore = GameObject.Find("Missscore").GetComponent<Text>();//2�̕�
        MaxScore = GameObject.Find("MaxScore").GetComponent<Text>();//2�̕�

        SetResultText();
       //int  ResultManager=GameManager.getsp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetResultText()
    {
        /*Score�\��*/
        Score = PlayerPrefs.GetInt("Score",Score);
        ResultText.text = Score.ToString();//2
        //ResultText.text = "Score:" + Score.ToString();//��

        Debug.Log(":Load" + Score);
        Debug.Log(":Set" + Score);

        /*�p�t�F�\��*/
        Perfect = PlayerPrefs.GetInt("Perfect", Perfect);
        PerfecrScore.text = Perfect.ToString();//2

        Debug.Log(":Load" + Perfect);
        Debug.Log(":Set" + Perfect);

        /*�O���\��*/
        Great = PlayerPrefs.GetInt("Great", Great);
        GreatScore.text = Great.ToString();//2

        Debug.Log(":Load" + Great);
        Debug.Log(":Set" + Great);

        /*�O�h�\��*/
        Good = PlayerPrefs.GetInt("Good", Good);
        GoodScore.text = Good.ToString();//2

        Debug.Log(":Load" + Good);
        Debug.Log(":Set" + Good);

        /*�o�b�h�\��*/
        Bad = PlayerPrefs.GetInt("Bad", Bad);
        BadScore.text = Bad.ToString();//2

        Debug.Log(":Load" + Bad);
        Debug.Log(":Set" + Bad);

        /*�~�X�\��*/
        Miss = PlayerPrefs.GetInt("Miss", Miss);
        Missscore.text = Miss.ToString();//2

        Debug.Log(":Load" + Miss);
        Debug.Log(":Set" + Miss);

        /*�R���{�\��*/
        MaxCombo = PlayerPrefs.GetInt("MaxCombo", MaxCombo);
        MaxScore.text = MaxCombo.ToString();//2

        Debug.Log(":Load" + MaxCombo);
        Debug.Log(":Set" + MaxCombo);
    }
    //public void LoadScore()
    //{
    //    Score = PlayerPrefs.GetInt("Score",0);
    //    Debug.Log(":Load" + Score);
    //}

    public void DelDate()
    {
        PlayerPrefs.DeleteAll();
    }
}
