
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayers : MonoBehaviour
{


    private GameObject Players;


    void Start()
    {

    }

    void Update()
    {

        Players = GameObject.FindGameObjectWithTag("Players");


        transform.position = new Vector3(Players.transform.position.x, Players.transform.position.y, -10);
       
    }
}
