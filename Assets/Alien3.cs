using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien3 : MonoBehaviour
{
    public int pointValue;
    public int direction;
    float speed;
    public GameObject bullet; // the GameObject to spawn
    Global g;
    float rightEnd;
    float leftEnd;
    float num_aliens;

    void Start()
    {
        GameObject obj = GameObject.Find("GlobalObject");
        g = obj.GetComponent<Global>();
        speed = 1.0f;
        pointValue = 10;
        direction = 1;
        rightEnd = 8;
        leftEnd = -10;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gp = g.Group;
        Group grw = gp.GetComponent<Group>();
        num_aliens = grw.list.Count;
        //Debug.Log("all aliens: " + num_aliens);

        //Physics engine handles movement, empty for now. }
        float step = speed * 40 / num_aliens * Time.deltaTime * direction; //slow it down
        rightEnd += step;
        leftEnd += step;

        transform.Translate(step, 0, 0);

        //limit movement left to right
        if (leftEnd <= -15.0f)
        {
            //Debug.Log("Reached Left");
            direction = 1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
        }
        else if (rightEnd >= 15.0f)
        {
            //Debug.Log("Reached Right");
            direction = -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
        }

        int ran = Random.Range(0, 10000);

        if (ran >= 9999 && g.livesRemaining > 0)
        {
            //Debug.Log("Fire!");
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
        //Debug.Log(other.name);
        if (other.gameObject.tag == "Bullet")
        {
            Die();
            AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
            Destroy(other.gameObject); //delete this bullet
        }
    }

    public void Die()
    {
        //AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        //Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        g = obj.GetComponent<Global>();
        g.score += pointValue;
        GameObject gp = g.Group;
        Group grw = gp.GetComponent<Group>();
        int index = grw.list.IndexOf(gameObject);
        //Debug.Log(grw.list.Count);

        Destroy(gameObject);
        grw.list.RemoveAt(index);
    }
}
