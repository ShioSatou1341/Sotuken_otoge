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
        if (Input.GetKeyUp(KeyCode.Return))//ノーツ流し終わったら終了判定ほしかったね
        {
            SceneManager.LoadScene("MenuScene");//メニューにもどる

        }
    }

    public void PushTitleBackButton()
    {
        SceneManager.LoadScene("MenuScene");//メニューにもどる
    }
    public void PushYesButton()
    {
        SceneManager.LoadScene("PlayScene");//
    }
    
}
