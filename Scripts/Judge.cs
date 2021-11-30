using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    private GameObject gameManager;
    private bool OnOff;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.1f); // 1•b‚ÅÁ‚·
        gameManager = GameObject.Find("GameManager");
        Debug.Log("”»’è¶¬");
        OnOff = true;
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(gameObject);//ƒm[ƒc‚ª‚Ô‚Â‚©‚Á‚½‚çÁ‚·

    }


    void OnTriggerExit2D(Collider2D coll)
    {
        if (i==1)
        {
            Debug.Log("”»’èDelete"+i);
            gameManager.GetComponent<GameManager>().ComboAdd();
            gameManager.GetComponent<GameManager>().judgeKind(1);
            i++;
        }


    }
}
