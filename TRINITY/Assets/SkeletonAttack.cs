using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    private ninja life;
    int dmg = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        life = GameObject.FindGameObjectWithTag("Players").GetComponent<ninja>();
        //archer = GameObject.FindGameObjectWithTag("Player").GetComponent<Arquero>();
        //boxer = GameObject.FindGameObjectWithTag("Player").GetComponent<Fighter>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Players"))
        {
           
            collision.SendMessageUpwards("Damage", dmg);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
