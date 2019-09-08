using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 thrust;
    // Use this for initialization
    void Start()
    {
        // travel straight in the z-axis
        thrust.z = -400.0f;
        // do not passively decelerate
        GetComponent<Rigidbody>().drag = 0;
        // apply thrust once, no need to apply it again since
        // it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    // Update is called once per frame
    void Update()
    { //Physics engine handles movement, empty for now. }


    }

    //public AudioClip deathExplosion
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        //MeshRenderer meshRend = GetComponent<MeshRenderer>();
        //meshRend.material.color = Color.green;
        //Debug.Log(other.name);
        if (other.gameObject.tag == "Bullet")
        {
            //AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
            Destroy(other.gameObject); //delete bullet
            Destroy(gameObject); //delete this alien
        }
    }
}
