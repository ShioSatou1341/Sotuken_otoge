using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static int sp = 0;//スコア
    //public GameObject Heal;//回復ノーツ
    public int Life;  //Life表示
    private int Score;//スコア

    private int totalCombo;//その時のコンボ数
    private int bestCombo;//最多コンボ数
    private Text comboText;//コンボ表示

    private Text judgeText;//判定表示

    private Text perfectText;//パフェノーツ数テキスト
    private int perfectNote;//パフェ判定ノーツの個数

    private Text greatText;//パフェノーツ数テキスト
    private int greatNote;//グレ判定ノーツの個数

    private Text goodText;//パフェノーツ数テキスト
    private int goodNote;//グッド判定ノーツの個数

    private Text badText;//パフェノーツ数テキスト
    private int badNote;//バッド判定ノーツの個数

    private Text missText;//パフェノーツ数テキスト
    private int missNote;//見逃しミス判定ノーツの個数

    private Text lifeText;//lifeのテキスト

    private Text scoreText;//scoreのテキスト

    private bool inGame;//ゲーム中か否か

    private Canvas resultCanvas;//リザルトキャンバス
    private Text resultText;//リザルト画面で出すコンボのテキスト
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
        resultCanvas.enabled = false;//非表示
        perfectText = GameObject.Find("perfectText").GetComponent<Text>();
        greatText = GameObject.Find("greatText").GetComponent<Text>();
        goodText = GameObject.Find("goodText").GetComponent<Text>();
        badText = GameObject.Find("badText").GetComponent<Text>();
        missText = GameObject.Find("missText").GetComponent<Text>();
        lifeText = GameObject.Find("Life").GetComponent<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        SetlifeText();
        SetscoreText(Score);

        PlayerPrefs.SetString("Play", SceneManager.GetActiveScene().name);//今動かしてる譜面のシーンを取得
        PlayerPrefs.Save();
        

        inGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        //int val = int.Parse(comboText.text);
        //if (inGame == true)
        //{
        //    if (Input.GetKeyUp(KeyCode.Return))//ノーツ流し終わったら終了判定ほしかったね
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

        if (bestCombo < totalCombo)//最多コンボの記録
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
        if (Life < 10)//Life上限10とする
        {
            Life += 1;
            SetlifeText();
        }

    }

    public void judgeKind(int num)
    {
        switch (num)
        {
            case 1://パフェ
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

            case 2://グレ
                //ComboAdd();
                greatNote++;
                PlayerPrefs.SetInt("Great", greatNote);
                PlayerPrefs.Save();
                //回復ノーツにあたると１回復
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
            case 3://グド
                //ComboAdd();
                goodNote++;
                PlayerPrefs.SetInt("Good", goodNote);
                PlayerPrefs.Save();
                //回復ノーツにあたると１回復
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

                if (Life == 0)//lifeが０になったら
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
                judgeText.text = ("MISS…");
                //Debug.Log("MISS");
                if (Life == 0)//lifeが０になったら
                {

                    SceneManager.LoadScene("GameOverScene");
                }
                break;
        }
        

    }
    /*――――――――――――――――――――――――――――――――――*/


}
//ここに必要なもの
//・スコア計算
//・（ジャッジごとに仕事分ける？）
//・曲が終わったらシーン遷移
//