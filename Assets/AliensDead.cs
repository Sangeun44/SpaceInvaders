using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensDead : MonoBehaviour
{
    List<GameObject> listOfOpponents = new List<GameObject>();

    //void Start()
    //{
    //    listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Alien1"));
    //    listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Alien2"));
    //    listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Alien3"));

    //    print(listOfOpponents.Count);
    //}

    //public void KilledOpponent(GameObject opponent)
    //{
    //    if (listOfOpponents.Contains(opponent))
    //    {
    //        listOfOpponents.Remove(opponent);
    //    }

    //    print(listOfOpponents.Count);
    //}

    //void Update()
    //{
    //    Debug.Log("aliends: " + listOfOpponents.Count);

    //    if (listOfOpponents.Count <= 0)
    //    {
    //        // They are dead!
    //        Debug.Log("dead");
    //    }
    //    else
    //    {
    //        // They're still alive dangit
    //    }
    //}
}