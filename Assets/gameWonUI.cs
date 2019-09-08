﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameWonUI : MonoBehaviour
{
    Global globalObj;
    Text gameWonTXT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        gameWonTXT = gameObject.GetComponent<Text>();
        gameWonTXT.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (globalObj.playerWon)
        {
            gameWonTXT.enabled = true;
        }
    }

}