using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject objToSpawn;
    public int score;
    public int hiscore;
    public int livesRemaining;
    public int level;

    // Use this for initialization
    void Start()
    {
        level = 1;
        livesRemaining = 3;
        score = 0;
        hiscore = 0;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
