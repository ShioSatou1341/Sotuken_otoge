using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject button_music1;
    public GameObject button_music2;
    public GameObject button_music3;
    public GameObject button_music4;
    //public GameObject button_music5;
    //public GameObject button_music6;
    public Button button_back;

    public AudioClip AudioSE;
    private AudioSource audiosource;

    public Text dftext;
    public Text dftext2;
    //public Text dftext3;

    int t = 0;
    public int musicNum;//ã»êîÇ¢Ç∂ÇÈ

    // Start is called before the first frame update
    void Start()
    {

        t = 0;  //swichï∂ÇÃïœêî
        dftext = GameObject.Find("Canvas/MusicTitle1").GetComponent<Text>();
        dftext2 = GameObject.Find("Canvas/MusicTitle2").GetComponent<Text>();
        //dftext3 = GameObject.Find("Canvas/MusicTitle3").GetComponent<Text>();
        dftext.enabled = false;
        dftext2.enabled = false;
        //dftext3.enabled = false;

        button_back = GameObject.Find("Canvas/Titleback").GetComponent<Button>();

        button_music1.SetActive(false);
        button_music2.SetActive(false);
        button_music3.SetActive(false);
        button_music4.SetActive(false);
        //button_music5.SetActive(false);
        //button_music6.SetActive(false);

        //button_music1 = GameObject.Find("Canvas/Shorteasy1").GetComponent<Button>();
        //button_music2 = GameObject.Find("Canvas/ShortHard2").GetComponent<Button>();
        //button_music3 = GameObject.Find("Canvas/Shorteasy3").GetComponent<Button>();
        //button_music4 = GameObject.Find("Canvas/ShortHard4").GetComponent<Button>();
        //button_text1 = GameObject.Find("Canvas/Shorteasy1/dfeasyS1").GetComponent<Text>();
        //button_text2 = GameObject.Find("Canvas/ShortHard2/dfhardS2").GetComponent<Text>();
        //button_text3 = GameObject.Find("Canvas/Shorteasy3/dfeasyS3").GetComponent<Text>();
        //button_text4 = GameObject.Find("Canvas/ShortHard4/dfhardS4").GetComponent<Text>();
        //button_music1.enabled = false;
        //button_music2.enabled = false;
        //button_music3.enabled = false;
        //button_music4.enabled = false;
        //button_text1.enabled = false;
        //button_text2.enabled = false;
        //button_text3.enabled = false;
        //button_text4.enabled = false;
        audiosource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        ButtonSelect();
        YajirusiUP();
        YajirusiDown();

        switch (t)
        {
            case 0:
                NANNIDO();
                break;
            case 1:
                NANNIDO2();
                break;
            //case 2:
            //    NANNIDO3();
            //    break;
            default:
                break;
        }

        //if(Input.GetKeyDown(KeyCode.B))
        //{
        //    TITLE();   //ãŸã}
        //}
        if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("TitleScene");
        }



    }

    public void NANNIDO()
    {
        dftext.enabled = true;
        dftext2.enabled = false;
        //dftext3.enabled = false;

        button_music1.SetActive(true);
        button_music2.SetActive(true);
        button_music3.SetActive(false);
        button_music4.SetActive(false);
        //button_music5.SetActive(false);
        //button_music6.SetActive(false);

        //button_music1.enabled = true;
        //button_music2.enabled = true;
        //button_music3.enabled = false;
        //button_music4.enabled = false;

        //button_text1.enabled = true;
        //button_text2.enabled = true;
        //button_text3.enabled = false;
        //button_text4.enabled = false;

        Debug.Log("music1");

        if (Input.GetKey(KeyCode.Return))
        {
            //audiosource.PlayOneShot(AudioSE);
            SceneManager.LoadScene("DifficultScene");
            
        }
        Button_Move();
    }

    public void NANNIDO2()
    {
        dftext.enabled = false;
        dftext2.enabled = true;
        //dftext3.enabled = false;

        button_music1.SetActive(false);
        button_music2.SetActive(false);
        button_music3.SetActive(true);
        button_music4.SetActive(true);
        //button_music5.SetActive(false);
        //button_music6.SetActive(false);

        //button_music1.enabled = false;
        //button_music2.enabled = false;
        //button_music3.enabled = true;
        //button_music4.enabled = true;

        //button_text1.enabled = false;
        //button_text2.enabled = false;
        //button_text3.enabled = true;
        //button_text4.enabled = true;

        Debug.Log("music2");
        if (Input.GetKey(KeyCode.Return))
        {
            //audiosource.PlayOneShot(AudioSE);
            SceneManager.LoadScene("DifficultScene2");

        }
        Button_Move();
    }

    //public void NANNIDO3()
    //{
    //    int Nannidos = 0;

    //    dftext.enabled = false;
    //    dftext2.enabled = false;
    //    //dftext3.enabled = true;

    //    button_music1.SetActive(false);
    //    button_music2.SetActive(false);
    //    button_music3.SetActive(true);
    //    button_music4.SetActive(true);
    //    //button_music5.SetActive(true);
    //    //button_music6.SetActive(true);

    //    Debug.Log("music3");

    //    if (Input.GetKey(KeyCode.Return))
    //    {
    //        //audiosource.PlayOneShot(AudioSE);
    //        SceneManager.LoadScene("DifficultScene3");
    //    }
    //    Button_Move();
    //}
    public void TITLE()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    public void Button_Move()
    {

        //É{É^ÉìÇ™ëIëÇ≥ÇÍÇΩèÛë‘Ç…Ç»ÇÈ
        //button_music1.Select();
    }

    public void ButtonSelect()
    {
        switch (transform.name)
        {
            case "Shorteasy":
                break;
            case "Shorthard":
                break;
            case "Titleback":
                TITLE();
                break;
            default:
                break;
        }
    }

    public void YajirusiUP()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            t++;

            if (t >= musicNum)
            {
                t = 0;
            }

        }


    }

    public void YajirusiDown()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            t--;

            if (t <= -1)
            {
                t = musicNum-1;
            }
        }
    }


}
