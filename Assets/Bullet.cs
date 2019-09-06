using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 thrust;
    // Use this for initialization
    void Start()
    {
        // travel straight in the z-axis
        thrust.z = 400.0f;
        // do not passively decelerate
        GetComponent<Rigidbody>().drag = 0;
        // apply thrust once, no need to apply it again since
        // it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    // Update is called once per frame
    void Update()
    { //Physics engine handles movement, empty for now. }
        //float speed = 10.0f;
        //float step = speed * Time.deltaTime; //slow it down
        //transform.Translate(10.0f, 0, 0);

        ////limit movement left to right
        //if (transform.position.x <= -15.5f)
        //{
        //    transform.position = new Vector3(-15.5f, transform.position.y, transform.position.z);
        //} else if (transform.position.x >= 15.5f) {
        //    transform.position = new Vector3(15.5f, transform.position.y, transform.position.z);
        //}

    }

    void OnCollisionEnter(Collision collision)
    {
        _ = collision.collider;

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Alien1")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Destory the alien!");

        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Alien1")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }

}
