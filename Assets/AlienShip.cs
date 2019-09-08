using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
    public int pointValue;
    Global globalObj;
    float speed = 10.0f;
    int direction; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();

        int[] points = { 50, 100, 500 };
        int ran = Random.Range(0, 2);
        direction = globalObj.direction;
        pointValue = points[ran];
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
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        //MeshRenderer meshRend = GetComponent<MeshRenderer>();
        //meshRend.material.color = Color.green;
        if (other.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(deathExplosion, gameObject.transform.position);
            Destroy(other.gameObject); //delete bullet
            Die();
        }
    }

    public void Die()
    {
        //AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
        //Instantiate(deathExplosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
        GameObject obj = GameObject.Find("GlobalObject");
        Global g = obj.GetComponent<Global>();
        g.score += pointValue;
        Destroy(gameObject);
    }
}
