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


    // Start is called before the first frame update
    void Start()
    {
        button_easy = GameObject.Find("Canvas/nanido/Easy").GetComponent<Button>();
        button_hard = GameObject.Find("Canvas/nanido/Hard").GetComponent<Button>();
        button_back = GameObject.Find("Canvas/BackButton").GetComponent<Button>();

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
    }

    public void EASY()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Kirakiraboshi_easy");
            Debug.Log("�ȒP");
        }
    }

    public void HARD()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Kirakiraboshi_hard"); //��
            Debug.Log("���Y�C");
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

        //�{�^�����I�����ꂽ��ԂɂȂ�
        button_easy.Select();
    }
}
