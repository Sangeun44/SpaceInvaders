using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject g = GameObject.Find("GlobalObject");
        Global globalObj = g.GetComponent<Global>();
        GameObject player = globalObj.Laser;
        //transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
    }
}
