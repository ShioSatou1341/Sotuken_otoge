using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PLAY();
        TITLE();
    }

    public void PLAY()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
    public void TITLE()
    {
        if (Input.GetKeyDown("b"))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
