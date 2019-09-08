using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bunker : MonoBehaviour
{
    int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        MeshRenderer meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip wow;

    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        //Debug.Log(other.name);
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Attack")
        {
            AudioSource.PlayClipAtPoint(wow, gameObject.transform.position);
            Destroy(other.gameObject);
            gameObject.transform.localScale -= new Vector3(0.5f, 0, 0);
            if (health == 0) {
                Destroy(gameObject);
            }
            health--;
        }
    }
}
