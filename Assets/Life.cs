using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Vector3 thrust;
    public bool alive;
    // Use this for initialization

    void Start()
    {
        alive = true;
        // travel straight in the z-axis
        thrust.y = -700.0f;
        // do not passively decelerate

        GetComponent<Rigidbody>().drag = 0;
        // apply thrust once, no need to apply it again since
        // it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
        GetComponent<Rigidbody>().AddRelativeTorque(thrust);
        Physics.IgnoreLayerCollision(12, 8);
        Physics.IgnoreLayerCollision(12, 9);
        Physics.IgnoreLayerCollision(12, 10);
        Physics.IgnoreLayerCollision(12, 13);
        Physics.IgnoreLayerCollision(12, 14);
        Physics.IgnoreLayerCollision(12, 15);
        Physics.IgnoreLayerCollision(12, 12);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioClip sparkle;
    public GameObject sparkling;

    //public AudioClip deathExplosion
    void OnCollisionEnter(Collision collision)
    {

        if (alive)
        {           

            if (collision.collider.gameObject.tag == "Laser")
            {
                AudioSource.PlayClipAtPoint(sparkle, gameObject.transform.position);
                Instantiate(sparkling, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
                Die();
                Debug.Log("life hit laser");
            }

            if (collision.collider.gameObject.tag == "Floor")
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                alive = false;
                Destroy(gameObject);
            }
        }

    }


    public void Die()
    {

        Debug.Log("life died");
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.livesRemaining += 1;
        alive = false;
        Destroy(gameObject);
        Debug.Log("died");
    }
}
