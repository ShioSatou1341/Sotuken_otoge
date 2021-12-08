using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushTitleBackButton()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void PushYesButton()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
