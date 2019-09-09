using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public int score;
    public int hiscore = 0;
    public int livesRemaining;
    public int level=0;

    public bool playerDied;
    public bool gameOver;
    public bool playerWon;

    public int direction = -1;

    public GameObject AlienShip;
    public GameObject Laser;
    public GameObject Group;


    // Use this for initialization
    void Start()
    {
        level++;
        livesRemaining = 3;
        score = 0;

        Laser = Instantiate(Laser, new Vector3(0, 0, -20), Quaternion.identity);
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
            //StartCoroutine("ReStart", 15.0f); //respawn
        }

        // make alien ships that will move at the back row
        int ran = Random.Range(0, 10000);
        if (ran >= 9990 && livesRemaining > 0 && !playerWon && !playerDied)
        {
            Instantiate(AlienShip, new Vector3(40 * direction*-1, 0, 35), Quaternion.identity);
        }


        if (playerDied && livesRemaining > 0)
        {
            Debug.Log("In" + " " + Time.deltaTime);
            Debug.Log("Player died");
            playerDied = false;
            Laser = Instantiate(Laser, transform.position, Quaternion.identity);
           
            //StartCoroutine("Respawn", 3.0f); //respawn
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R) && livesRemaining == 0)
        {
            Debug.Log("Player pressed R");
            SceneManager.LoadScene(1);
        }

    }




    //IEnumerator ReStart(float Count)
    //{
    //    yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
    //    Start();
    //    //And here goes your method of resetting the game...
    //    yield return null;
    //}

}
