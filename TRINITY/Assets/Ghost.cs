using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : MonoBehaviour
{

    public float speed;
    public float lineofSite;
    private Transform Players;
    public float shootingRange;
    public float fireRate = 1f;
    public GameObject bloodEffect;
    public int health;
    


    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectWithTag("Players").transform;
      

    }

  
    // Update is called once per frame
    void Update()

    {


        if (health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("mort", true);
            Destroy(gameObject);

        }
        positiondetector();
        float distanceFromPlayer = Vector2.Distance(Players.position, transform.position);
        if (distanceFromPlayer < lineofSite && distanceFromPlayer > shootingRange)
        {

            transform.position = Vector2.MoveTowards(this.transform.position, Players.position, speed * Time.deltaTime);

        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private void positiondetector()
    {

        if (Players.position.x > shootingRange / 2)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //gameObject.GetComponent<SpriteRenderer>().Bee_bullet.flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }


    }

    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Debug.Log(damage);
        Debug.Log(health);
        health -= damage;
        Debug.Log("damage TaKEN !");

    }
}
