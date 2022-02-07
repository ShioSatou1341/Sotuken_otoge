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
        //ResultText = GameObject.Find("ResultText").GetComponent<Text>();  //元
        ResultText = GameObject.Find("ScoreText").GetComponent<Text>();//2の方
        PerfecrScore = GameObject.Find("PerfecrScore").GetComponent<Text>();//2の方
        GreatScore = GameObject.Find("GreatScore").GetComponent<Text>();//2の方
        GoodScore = GameObject.Find("GoodScore").GetComponent<Text>();//2の方
        BadScore = GameObject.Find("BadScore").GetComponent<Text>();//2の方
        Missscore = GameObject.Find("Missscore").GetComponent<Text>();//2の方
        MaxScore = GameObject.Find("MaxScore").GetComponent<Text>();//2の方

        SetResultText();
       //int  ResultManager=GameManager.getsp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetResultText()
    {
        /*Score表示*/
        Score = PlayerPrefs.GetInt("Score",Score);
        ResultText.text = Score.ToString();//2
        //ResultText.text = "Score:" + Score.ToString();//元

        Debug.Log(":Load" + Score);
        Debug.Log(":Set" + Score);

        /*パフェ表示*/
        Perfect = PlayerPrefs.GetInt("Perfect", Perfect);
        PerfecrScore.text = Perfect.ToString();//2

        Debug.Log(":Load" + Perfect);
        Debug.Log(":Set" + Perfect);

        /*グレ表示*/
        Great = PlayerPrefs.GetInt("Great", Great);
        GreatScore.text = Great.ToString();//2

        Debug.Log(":Load" + Great);
        Debug.Log(":Set" + Great);

        /*グド表示*/
        Good = PlayerPrefs.GetInt("Good", Good);
        GoodScore.text = Good.ToString();//2

        Debug.Log(":Load" + Good);
        Debug.Log(":Set" + Good);

        /*バッド表示*/
        Bad = PlayerPrefs.GetInt("Bad", Bad);
        BadScore.text = Bad.ToString();//2

        Debug.Log(":Load" + Bad);
        Debug.Log(":Set" + Bad);

        /*ミス表示*/
        Miss = PlayerPrefs.GetInt("Miss", Miss);
        Missscore.text = Miss.ToString();//2

        Debug.Log(":Load" + Miss);
        Debug.Log(":Set" + Miss);

        /*コンボ表示*/
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
