using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 thrust;
	Global globalObj;
    public bool alive;

	// Use this for initialization
	void Start()
    {
		GameObject g = GameObject.Find("GlobalObject");
		globalObj = g.GetComponent<Global>();
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.red;
        alive = true;
		// travel straight in the z-axis
		thrust.y = 500.0f;
        // do not passively decelerate
        GetComponent<Rigidbody>().drag = 0;
        // apply thrust once, no need to apply it again since it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioClip deathExplosion;
    void OnCollisionEnter(Collision collision)
    {
        if (alive) {
            if (collision.collider.gameObject.tag == "Alien1" || collision.collider.gameObject.tag == "Alien2" || collision.collider.gameObject.tag == "Alien3")
            {
                alive = false;
                MeshRenderer meshRend = GetComponent<MeshRenderer>();
                meshRend.material.color = Color.gray;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, -2, 0);
            }
        }
    }
}
