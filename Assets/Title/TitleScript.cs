using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
		GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Start Game";
		GameObject.Find("Button2").GetComponentInChildren<Text>().text = "Exit";

	}

	// Update is called once per frame
	public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }


}