using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultButton : MonoBehaviour
{
    public Button button_easy;
    public Button button_hard;
    public Button button_back;

    private Text musicTitleText;

    // Start is called before the first frame update
    void Start()
    {
        button_easy = GameObject.Find("Canvas/nanido/Easy").GetComponent<Button>();
        button_hard = GameObject.Find("Canvas/nanido/Hard").GetComponent<Button>();
        button_back = GameObject.Find("Canvas/BackButton").GetComponent<Button>();
        
        musicTitleText = GameObject.Find("musicTitle").GetComponent<Text>();
        
        Button_Move();
    }

    // Update is called once per frame
    void Update()
    {
        switch (transform.name)
        {
            case "Easy":
                EASY();
                break;
            case "Hard":
                HARD();
                break;
            case "MenuBack":
                MENUBACK();
                break;
            default:
                break;
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void EASY()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (musicTitleText.text.ToString() == "キラキラ星")
            {
                SceneManager.LoadScene("Kirakiraboshi_easy");
            }
            else if(musicTitleText.text.ToString() == "Potato")
            {
                SceneManager.LoadScene("Potato_easy");            
            }
            else
            {
                SceneManager.LoadScene("Kirakiraboshi_easy");
            }
            Debug.Log("簡単");
        }
    }

    public void HARD()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (musicTitleText.text.ToString() == "キラキラ星")
            {
                SceneManager.LoadScene("Kirakiraboshi_hard");
            }
            else if (musicTitleText.text.ToString() == "Potato")
            {
                SceneManager.LoadScene("Potato_hard");
            }
            else
            {
                SceneManager.LoadScene("Kirakiraboshi_hard");
            }

            Debug.Log("ムズイ");
        }
    }

    public void MENUBACK()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MenuScene"); 
            
        }
    }

    public void Button_Move()
    {

        //ボタンが選択された状態になる
        button_easy.Select();
    }
}
