using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriguer : MonoBehaviour
{

    public int damage = 1;



    void OnTriggerEnter2D(Collider2D collide)
    {


        if (collide.isTrigger != true && collide.CompareTag("Enemy"))
        {
            collide.SendMessageUpwards("TakeDamage", damage);

            //GetComponent<Ghost>().TakeDamage(damage);
            //GetComponent<BeeFollowPlayer>().TakeDamage(damage);
        }
        if (collide.isTrigger != true && collide.CompareTag("BEE"))
        {
            collide.SendMessageUpwards("TakeDamage", damage);

            //GetComponent<Ghost>().TakeDamage(damage);
            //GetComponent<BeeFollowPlayer>().TakeDamage(damage);
        }
        if (collide.isTrigger != true && collide.CompareTag("SKELETON"))
        {
            collide.SendMessageUpwards("TakeDamage", damage);

            //GetComponent<Ghost>().TakeDamage(damage);
            //GetComponent<BeeFollowPlayer>().TakeDamage(damage);
        }

        if (collide.isTrigger != true && collide.CompareTag("Boss"))
        {
            collide.SendMessageUpwards("TakeDamage", damage);

            //GetComponent<Ghost>().TakeDamage(damage);
            //GetComponent<BeeFollowPlayer>().TakeDamage(damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}