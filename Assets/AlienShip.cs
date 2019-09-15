using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
    public int pointValue;
    Global globalObj;
    float speed = 10.0f;
    public bool alive;
    int direction; 
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();

        int[] points = { 50, 100, 500 };
        int ran = Random.Range(0, 2);
        direction = globalObj.direction;
        pointValue = points[ran];

        Physics.IgnoreLayerCollision(9, 8);

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime * direction; //slow it down
        //Debug.Log(step);
        this.transform.Translate(step, 0, 0);

        if (direction == -1 && this.transform.position.x < 40 * direction)
        {
            Destroy(gameObject);
            globalObj.direction = 1;
        }
        else if (direction == 1 && this.transform.position.x > 40 * direction)
        {
            Destroy(gameObject);
            globalObj.direction = -1;
        }
    }

    public AudioClip deathExplosion;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AlienShip collision");
        if (alive)
        {
            if (collision.collider.gameObject.tag == "Bullet")
            {
                Die();
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * -500);
            }
        }

    }

    public void Die()
    {
        gameObject.layer = 14;
        AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        Destroy(gameObject);
    }
}
