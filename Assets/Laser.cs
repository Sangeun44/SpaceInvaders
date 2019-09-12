using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject bullet; // the GameObject to spawn
    Global globalObj;

    public bool alive;

    // Use this for initialization
    void Start()
    {
        alive = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            audioSource.Play();
    }

    public AudioClip deathExplosion;
    public GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        //MeshRenderer meshRend = GetComponent<MeshRenderer>();
        //meshRend.material.color = Color.green;
        //Debug.Log(other.name);
        if (other.gameObject.tag == "Attack")
        {
            //Debug.Log("The enemy attack reached me");
            AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
            Instantiate(explosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
            Destroy(other.gameObject); //delete this bullet
            Die();
        }
    }

    public AudioClip pewpew;
    float speed = 15.0f;
    void Update()
    {
        //allow movement left to right
        float step = speed * Time.deltaTime; //slow it down
        transform.Translate(Input.GetAxis("Horizontal") * step, 0, 0);

        //limit movement left to right
        if (transform.position.x <= -25.0f)
        {
            transform.position = new Vector3(-25.0f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 25.0f)
        {
            transform.position = new Vector3(25.0f, transform.position.y, transform.position.z);
        }

        Debug.Log("comeback");

        //press space to shoot bullet
        if (Input.GetKeyDown("space"))
        {
            AudioSource.PlayClipAtPoint(pewpew, gameObject.transform.position);
            //Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
            //Debug.Log("Fire!");
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z += 2.5f;
            // instantiate the Bullet
            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
            // get the Bullet Script Component of the new Bullet instance
            //Bullet b = obj.GetComponent<Bullet>();

        }
    }

    public void Die()
    {
        //AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        //Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.livesRemaining -= 1;
        g.playerDied = true;
        alive = true;
        //Destroy(gameObject);
        Debug.Log("died");
    }

}
