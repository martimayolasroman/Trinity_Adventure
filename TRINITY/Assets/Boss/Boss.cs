using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player;

    public bool isFlipped = false;

    void Start()
    {

    }

    private void Update()
    {
       // player = GameObject.FindGameObjectWithTag("Players").transform;
        // players = GameObject.FindGameObjectWithTag("players").GetComponent<Transform>();

        //        transform.position = Vector2.MoveTowards(transform.position, players.position, speed * Time.deltaTime);
    }







    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }


}