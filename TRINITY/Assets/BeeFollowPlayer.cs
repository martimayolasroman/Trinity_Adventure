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

        
    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectWithTag("Players").transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance( Players.position, transform.position);
        if(distanceFromPlayer < lineofSite && distanceFromPlayer > shootingRange ) { 
        transform.position = Vector2.MoveTowards(this.transform.position, Players.position, speed * Time.deltaTime);
            
        }else if(distanceFromPlayer <= shootingRange && nextFireTime <Time.time)
        {
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
}
