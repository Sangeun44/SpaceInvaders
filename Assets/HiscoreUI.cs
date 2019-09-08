﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiscoreUI : MonoBehaviour
{
    Global globalObj;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        scoreText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		if (globalObj.livesRemaining == 0) {
			GameOver();
		}
    }

	void GameOver() {
		scoreText.text = globalObj.hiscore.ToString();

	}

}