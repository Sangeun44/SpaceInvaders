using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.green;
        GetComponent<Rigidbody>().drag = 0;
        // apply thrust once, no need to apply it again since
        // it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);

    }

    // Update is called once per frame
    void Update()
    { 

    }


    //public AudioClip deathExplosion
    public AudioClip deathExplosion;
    void OnCollisionEnter(Collision collision)
    {

        if(alive)
        {
            alive = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, -100, 0);

            if (collision.collider.gameObject.tag == "Bullet")
            {
                gameObject.layer = 10;
                MeshRenderer meshRend = GetComponent<MeshRenderer>();
                meshRend.material.color = Color.gray;
            }

            if(collision.collider.gameObject.tag == "Laser")
            {
                gameObject.layer = 10;
                MeshRenderer meshRend = GetComponent<MeshRenderer>();
                meshRend.material.color = Color.gray;
                AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
                collision.collider.gameObject.GetComponent<Laser>().Die();
            }

            if (collision.collider.gameObject.tag == "Floor")
            {
                gameObject.layer = 10;
                MeshRenderer meshRend = GetComponent<MeshRenderer>();
                meshRend.material.color = Color.gray;
            }
        }

    }
}
