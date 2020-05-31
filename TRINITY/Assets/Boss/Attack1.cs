using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{

    public int attackDamage = 1 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Players"))
        {

            collision.SendMessageUpwards("Damage", attackDamage);
            Debug.Log("DAMGE");
            //audioPlayer.clip = atackClip;
            //audioPlayer.Play();

        }

    }
}
