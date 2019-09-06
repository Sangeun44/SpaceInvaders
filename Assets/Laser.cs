using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject bullet; // the GameObject to spawn

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        //allow movement left to right
        float speed = 10.0f;
        float step = speed * Time.deltaTime; //slow it down
        transform.Translate(Input.GetAxis("Horizontal") * step, 0, 0);

        //limit movement left to right
        if (transform.position.x <= -20.0f)
        {
            transform.position = new Vector3(-20.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 20.0f)
        {
            transform.position = new Vector3(20.0f, transform.position.y, transform.position.z);
        }

        //press space to shoot bullet
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Fire!");
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z += 2.5f;
            // instantiate the Bullet
            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
            // get the Bullet Script Component of the new Bullet instance
            Bullet b = obj.GetComponent<Bullet>();
        }
    }



}
