using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            StartCoroutine("turnOff", 3.0f); //respawn
        }
    }

    IEnumerator turnOff(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
                                                //And here goes your method of resetting the game...
        gameWonTXT.enabled = false;
        yield return null;
    }
}