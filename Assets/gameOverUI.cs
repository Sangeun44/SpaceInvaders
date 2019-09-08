using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverUI : MonoBehaviour
{
    Global globalObj;
    
    Text gameOverTXT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        gameOverTXT = gameObject.GetComponent<Text>();
        gameOverTXT.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalObj.livesRemaining == 0) {
            gameOverTXT.enabled = true;
        }
    }

}