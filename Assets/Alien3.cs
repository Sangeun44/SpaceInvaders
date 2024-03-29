﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien3 : MonoBehaviour
{

    public int pointValue;
    public int direction;
    float speed;

    public GameObject bullet; // the GameObject to spawn
    Global g;
    Group grw;
    float rightEnd;
    float leftEnd;
    float num_aliens;
    GameObject obj;
    GameObject gp;

    public bool alive;

    void Start()
    {
        //up speed

        obj = GameObject.Find("GlobalObject");
        g = obj.GetComponent<Global>();
        gp = g.Group;
        grw = gp.GetComponent<Group>();
        speed = 1.0f;
        pointValue = 30;
        direction = 1;
        rightEnd = 8;
        leftEnd = -10;
        alive = true;
        speed *= g.level;

        //ignore
        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(8, 15);
        Physics.IgnoreLayerCollision(8, 14);


    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (transform.position.y < -15 && this.gameObject.layer != 14)
            {
                Debug.Log("Alien1 reached end");
                g.gameOver = true;
            }
            num_aliens = grw.list.Count;

            float step = speed * 40 / num_aliens * Time.deltaTime * direction; //slow it down
            rightEnd += step;
            leftEnd += step;

            transform.Translate(step, 0, 0);

            //limit movement left to right
            if (leftEnd <= -15.0f)
            {
                direction = 1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
            }
            else if (rightEnd >= 15.0f)
            {
                direction = -1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);
            }

            int ran = Random.Range(0, 10000);

            if (ran >= 9997 && g.livesRemaining > 0)
            {
                Vector3 spawnPos = gameObject.transform.position;
                spawnPos.y -= 2.5f;
                // instantiate the Bullet
                Instantiate(bullet, spawnPos, Quaternion.identity);
            }
        }


    }

    public AudioClip deathExplosion;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Alien3 collision");
        if (alive)
        {
            if (collision.collider.gameObject.tag == "Bullet")
            {
                Die();
                AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);

                gameObject.layer = 14;

                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -500);
            }
        }
       
    }

    //public GameObject deathExplosion;
    //public AudioClip deathKnell;
    public void Die()
    {
        //AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        //Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        obj = GameObject.Find("GlobalObject");
        g = obj.GetComponent<Global>();
        g.score += pointValue;
        alive = false;
        int index = grw.list.IndexOf(gameObject);
        //Debug.Log("Alien3: " + index);
        grw.list.RemoveAt(index);
    }
}
