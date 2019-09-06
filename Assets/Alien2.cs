using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien2 : MonoBehaviour
{
    public int pointValue;
    public int direction;
    float speed;

    float rightEnd;
    float leftEnd;

    void Start()
    {
        speed = 1.0f;
        pointValue = 10;
        direction = 1;
        rightEnd = 8;
        leftEnd = -8;
    }

    // Update is called once per frame
    void Update()
    {
        //Physics engine handles movement, empty for now. }
        float step = speed * Time.deltaTime * direction; //slow it down
        rightEnd += step;
        leftEnd += step;

        transform.Translate(step, 0, 0);

        //limit movement left to right
        if (leftEnd <= -15.0f)
        {
            Debug.Log("Reached Left");
            direction = 1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
        }
        else if (rightEnd >= 15.0f)
        {
            Debug.Log("Reached Right");
            direction = -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.0f);
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
