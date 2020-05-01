using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeeFollowPlayer : MonoBehaviour
{

    public float speed;
    public float lineofSite;
    private Transform Players;
    
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    public int health;
    public GameObject bloodEffect;
    private ninja life;
    int dmg = 1;
    //public LayerMask players;




    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectWithTag("Players").transform;
      //  life = GameObject.FindGameObjectWithTag("Players").GetComponent<ninja>();

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

        if (health <= 0)
        {
            Destroy(gameObject);

        }
        positiondetector();
        float distanceFromPlayer = Vector2.Distance( Players.position, transform.position);
        if(distanceFromPlayer < lineofSite && distanceFromPlayer > shootingRange ) {
           
        transform.position = Vector2.MoveTowards(this.transform.position, Players.position, speed * Time.deltaTime);
            
        }else if(distanceFromPlayer <= shootingRange && nextFireTime <Time.time)
        {
            gameObject.GetComponent<Animator>().SetBool("attack", true);
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            
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

        if(Players.position.x > shootingRange / 2)
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
