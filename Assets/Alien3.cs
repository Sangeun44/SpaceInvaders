using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien3 : MonoBehaviour
{
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        pointValue = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
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
