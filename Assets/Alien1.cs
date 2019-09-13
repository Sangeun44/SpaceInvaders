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

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

    }

    // Update is called once per frame
    void Update()
    {
        if (alive) {
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
                GameObject attack = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
            }
        }       
    }

    public AudioClip deathExplosion;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Alien1 collision");
        if (collision.collider.gameObject.tag == "Attack")
        {
            Debug.Log("attack and alien collision 1");
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
        }

        if (alive) {
        
            if (collision.collider.gameObject.tag == "Bullet")
            {
                //collision with bullet
                //make sure alien dies            
                Die();
                AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);

                MeshRenderer meshRend = GetComponent<MeshRenderer>();
                meshRend.material.color = Color.red;

                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -500);
            }
 
        }


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
