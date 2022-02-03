using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public Button button_play;
    public Button button_menu;


    // Start is called before the first frame update
    void Start()
    {
        button_play = GameObject.Find("Canvas/Buttonseiretu/ButtonPlay").GetComponent<Button>();
        button_menu = GameObject.Find("Canvas/Buttonseiretu/ButtonMenu").GetComponent<Button>();
        //button.Select();
        Button_Move();
    }

    // Update is called once per frame
    void Update()
    {
        switch (transform.name)
        {
            case "ButtonPlay":
                PLAY();
                break;
            case "ButtonMenu":
                MENU();
                break;
            default:
                break;
        }
        
        
       
    }

    public void MENU()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void PLAY()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //SceneManager.LoadScene("ResultScene2"); //��
            SceneManager.LoadScene(PlayerPrefs.GetString("Play", "MenuScene")); //��
        }
    }

    public void Button_Move()
    {
        
        //�{�^�����I�����ꂽ��ԂɂȂ�
        button_play.Select();
    }
}
