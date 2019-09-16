﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public int score;
    public int hiscore;
    public int livesRemaining;
    public int level;

    public bool playerDied;
    public bool gameOver;
    public bool playerWon;
    public bool restart;

    public int direction;

    public GameObject AlienShip;
    public GameObject Laser;
    public GameObject Group;
    public GameObject Life;


    // Use this for initialization
    void Start()
    {
        level = 1;
        livesRemaining = 3;
        score = 0;
        direction = -1;
        Instantiate(Laser, new Vector3(0, -20, 0), Quaternion.identity);
        Group = Instantiate(Group);
        playerWon = false;
        playerDied = false;
        gameOver = false;
    }

    void StartAgain()
    {
        level++;
        livesRemaining++;
        score = 0;
        direction = -1;
        Instantiate(Laser, new Vector3(0, -20, 0), Quaternion.identity);
        Group = Instantiate(Group);
        playerWon = false;
        playerDied = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //keep track of high score
        if (score > hiscore) {
            hiscore = score;
        }

        //check if the aliens are all dead
        Group grw = Group.GetComponent<Group>();

        if (grw.list.Count == 0) {
            playerWon = true;
            Debug.Log("alien's are all dead");
            //StartCoroutine("ReStart", 15.0f); //respawn
        }

        // make alien ships that will move at the back row
        int ran = Random.Range(0, 10000);
        if (ran >= 9990 && livesRemaining > 0 && !playerWon && !GameObject.Find("AlienShip(Clone)"))
        {
            Instantiate(AlienShip, new Vector3(40 * direction*-1, 35, 0), Quaternion.identity);
        }

        int random = Random.Range(0, 10000);
        if (random >= 9990 && livesRemaining > 0 && !playerWon)
        {
            int random2 = Random.Range(-20, 20);
            Instantiate(Life, new Vector3(random2, 30, 0), Quaternion.identity);
        }

        if (playerDied && livesRemaining > 0)
        {
            Debug.Log("Player died");
            StartCoroutine("Respawn", 3.0f); //respawn
            playerDied = false;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R) && livesRemaining == 0)
        {
            Debug.Log("Player pressed R");
            gameOver = true;
            Start();         
        }

        restart = playerWon;
        
        if (restart && livesRemaining > 0)
        {
            restart = true;
            Debug.Log("start level+1");
            StartCoroutine("LevelCleared", 3.0f); //respawn
            restart = false;
        }
        if (gameOver) {
            livesRemaining = 0;
            GameObject player = GameObject.Find("Laser(Clone)");
            Destroy(player);
        }
    }

    IEnumerator LevelCleared(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        GameObject player = GameObject.Find("Laser(Clone)");
        Destroy(player);
        playerWon = false;
        StartAgain();
        StopCoroutine("LevelCleared");
        //And here goes your method of resetting the game...
        yield return null;
    }

    IEnumerator Respawn(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        Instantiate(Laser, new Vector3(0, -20, 0), Quaternion.identity);
        //And here goes your method of resetting the game...
        yield return null;
    }

}
