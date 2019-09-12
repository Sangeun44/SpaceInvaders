using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien1 : MonoBehaviour
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

    public bool alive;

    void Start()
    {
        alive = true;
        GameObject obj = GameObject.Find("GlobalObject");
        g = obj.GetComponent<Global>();
        GameObject gp = g.Group;
        grw = gp.GetComponent<Group>();
        speed = 1.0f;
        pointValue = 10;
        direction = 1;
        rightEnd = 8;
        leftEnd = -10;
    }

    // Update is called once per frame
    void Update()
    {
        num_aliens = grw.list.Count;
        //Debug.Log("all aliens: " + num_aliens);

        float step = speed *40/num_aliens * Time.deltaTime * direction; //slow it down
        rightEnd += step;
        leftEnd += step;

        transform.Translate(step, 0, 0);

        //limit movement left to right
        if (leftEnd <= -15.0f)
        {
            direction = 1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
        }
        else if (rightEnd >= 15.0f)
        {
            direction = -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
        }

        int ran = Random.Range(0, 10000);

        if (ran >= 9997 && g.livesRemaining > 0) {
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z += 2.5f;
            // instantiate the Bullet
            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
            // get the Bullet Script Component of the new Bullet instance
        }
       
    }

    public AudioClip deathExplosion;
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        //MeshRenderer meshRend = GetComponent<MeshRenderer>();
        //meshRend.material.color = Color.green;
        if (other.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
            //Destroy(other.gameObject); //delete bullet
            if (alive)
            {
                Die();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        //Destroy(gameObject);
    }

    public void Die()
    {
        //AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        //Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        g = obj.GetComponent<Global>();   
        g.score += pointValue;
        alive = false;
        int index = grw.list.IndexOf(gameObject);
        Debug.Log("Alien1: " + index);
        grw.list.RemoveAt(index);
    }
}
