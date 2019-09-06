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

    List<GameObject> list = new List<GameObject>();
    float left_end = -10;
    float right_end = 10;
    float direction = 1.0f; // direction 
    float speed = 2.0f;

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
            GameObject alien1 = Instantiate(Alien1, new Vector3(i*5-20, 0, 0), Quaternion.identity);
            alien1.name = "Alien1_" + "1" + i;
            //second row left
            GameObject alien2 = Instantiate(Alien1, new Vector3(i * 5 - 20, 0, 5), Quaternion.identity);
            alien2.name = "Alien1_" + "2" + i;
            //3rd row left
            GameObject alien3 = Instantiate(Alien2, new Vector3(i * 5 - 20, 0, 10), Quaternion.identity);
            alien3.name = "Alien2_" + "1" + i;
            //4th row left
            GameObject alien4 = Instantiate(Alien2, new Vector3(i * 5 - 20, 0, 15), Quaternion.identity);
            alien4.name = "Alien2_" + "2" + i;
            //5th row left
            GameObject alien5 = Instantiate(Alien3, new Vector3(i * 5 - 20, 0, 20), Quaternion.identity);
            alien5.name = "Alien3_" + "1" + i;
            list.Add(alien1);
            list.Add(alien2);
            list.Add(alien3);
            list.Add(alien4);
            list.Add(alien5);
        }
        //make right of the alien group
        for (int i = 0; i < 5; i++)
        {
            //first row right
            GameObject alien1 = Instantiate(Alien1, new Vector3(i * 5, 0, 0), Quaternion.identity);
            alien1.name = "Alien1_" + "1" + i + 5;
            //second row right
            GameObject alien2 = Instantiate(Alien1, new Vector3(i * 5, 0, 5), Quaternion.identity);
            alien2.name = "Alien1_" + "1" + i + 5;
            //3rd row left
            GameObject alien3 = Instantiate(Alien2, new Vector3(i * 5, 0, 10), Quaternion.identity);
            alien3.name = "Alien1_" + "1" + i + 5;
            //4th row left
            GameObject alien4 = Instantiate(Alien2, new Vector3(i * 5, 0, 15), Quaternion.identity);
            alien4.name = "Alien1_" + "1" + i + 5;
            //5th row left
            GameObject alien5 = Instantiate(Alien3, new Vector3(i * 5, 0, 20), Quaternion.identity);
            alien5.name = "Alien1_" + "1" + i + 5;
            list.Add(alien1);
            list.Add(alien2);
            list.Add(alien3);
            list.Add(alien4);
            list.Add(alien5);
        }

    }

}

