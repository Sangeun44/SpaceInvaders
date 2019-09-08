using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 thrust;
	Global globalObj;
	// Use this for initialization
	void Start()
    {
		GameObject g = GameObject.Find("GlobalObject");
		globalObj = g.GetComponent<Global>();

		// travel straight in the z-axis
		thrust.z = 1000.0f;
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

    public AudioClip deathExplosion;
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        //MeshRenderer meshRend = GetComponent<MeshRenderer>();
        //meshRend.material.color = Color.green;
        //Debug.Log(other.name);
        if (other.gameObject.tag == "Attack")
        {
            //AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
            Destroy(other.gameObject); //delete bullet
            Destroy(gameObject); //delete this alien
        }
    }

}
