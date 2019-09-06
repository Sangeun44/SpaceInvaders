using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Group : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject Alien1;
    public GameObject Alien2;
    public GameObject Alien3;
    Global globalObj;
    public int level;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        //GameObject gObj = GameObject.Find("GlobalObject");
        //Global g = gObj.GetComponent<Global>();
        //level = g.level;
        //Debug.Log("Level: " + level);

        //make left of the alien group
        for (int i = 0; i < 4; i++) {
            //first row left
            Instantiate(Alien1, new Vector3(i*5-20, 0, 0), Quaternion.identity);
            //second row left
            Instantiate(Alien1, new Vector3(i*5-20, 0, 5), Quaternion.identity);
            //3rd row left
            Instantiate(Alien2, new Vector3(i * 5 - 20, 0, 10), Quaternion.identity);
            //4th row left
            Instantiate(Alien2, new Vector3(i * 5 - 20, 0, 15), Quaternion.identity);
            //5th row left
            Instantiate(Alien3, new Vector3(i * 5 - 20, 0, 20), Quaternion.identity);
        }
        //make right of the alien group
        for (int i = 0; i < 5; i++)
        {
            //first row right
            Instantiate(Alien1, new Vector3(i*5, 0, 0), Quaternion.identity);
            //second row right
            Instantiate(Alien1, new Vector3(i*5, 0, 5), Quaternion.identity);
            //3rd row left
            Instantiate(Alien2, new Vector3(i * 5, 0, 10), Quaternion.identity);
            //4th row left
            Instantiate(Alien2, new Vector3(i * 5, 0, 15), Quaternion.identity);
            //5th row left
            Instantiate(Alien3, new Vector3(i * 5, 0, 20), Quaternion.identity);
        }

    }
}

