using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public GameObject notePrefab;

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
        judgeText = GameObject.Find("judgeText").GetComponent<Text>();
        comboText = GameObject.Find("Combo").GetComponent<Text>();

        resultCanvas = GameObject.Find("ResultCanvas").GetComponent<Canvas>();
        resultCanvas.enabled = false;//非表示
        perfectText = GameObject.Find("perfectText").GetComponent<Text>();
        greatText = GameObject.Find("greatText").GetComponent<Text>();
        goodText = GameObject.Find("goodText").GetComponent<Text>();
        badText = GameObject.Find("badText").GetComponent<Text>();
        missText = GameObject.Find("missText").GetComponent<Text>();





        inGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        //int val = int.Parse(comboText.text);
        if (inGame == true)
        {
            if (Input.GetKeyUp(KeyCode.Return))//ノーツ流し終わったら終了判定ほしかったね
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

            if (Input.GetKeyDown(KeyCode.Return))//ゲームが終わった後もう一度enterで次のシーン
            {

                SceneManager.LoadScene("ResultScene");
            }
        }



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

        if (bestCombo < totalCombo)//最多コンボの記録
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
            case 1://パフェ
                perfectNote++;
                judgeText.text = ("PERFECT!");
                Debug.Log("PERFECT");
                break;

            case 2://グレ
                greatNote++;
                judgeText.text = ("GREAT!");
                Debug.Log("GREAT");
                break;
            case 3://グド
                goodNote++;
                judgeText.text = ("GOOD");
                Debug.Log("GOOD");
                break;

            case 4:
                badNote++;
                judgeText.text = ("BAD");
                Debug.Log("BAD");
                break;

            default:
                missNote++;
                judgeText.text = ("MISS…");
                Debug.Log("MISS");
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
//判定表示BADとグレしか反応してない？（文字の切り替えもダメ）