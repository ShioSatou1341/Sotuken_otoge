using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    //private int ResultScore;
    private Text ResultText;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        ResultText = GameObject.Find("ResultText").GetComponent<Text>();
        SetResultText();
       //int  ResultManager=GameManager.getsp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetResultText()
    {
        Score=PlayerPrefs.GetInt("Score", Score);
        ResultText.text = "Score:" + Score.ToString();
        Debug.Log(":Load" + Score);
        Debug.Log(":Set" + Score);
       
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
