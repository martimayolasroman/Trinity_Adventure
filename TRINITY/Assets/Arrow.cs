using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    public float distance;
    public LayerMask whatIsEnemies;
    public LayerMask whatisground;
    public GameObject arrow;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo1 = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemies);
        if (hitInfo1.collider.CompareTag("BEE"))
        {
            //hitInfo.collider.GetComponent<Enemy_behaviour>().TakeDamage(damage);
            hitInfo1.collider.GetComponent<BeeFollowPlayer>().TakeDamage(damage);
            arrow.transform.gameObject.SetActive(false);



        }
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemies);

        if (hitInfo2.collider.CompareTag("SKELETON"))
        {
            //hitInfo.collider.GetComponent<Enemy_behaviour>().TakeDamage(damage);

            hitInfo2.collider.GetComponent<Enemy_behaviour>().TakeDamage(damage);
            arrow.transform.gameObject.SetActive(false);



        }

        RaycastHit2D hitInfo3 = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemies);

        if (hitInfo3.collider.CompareTag("Enemy"))
        {

            arrow.transform.gameObject.SetActive(false);

            hitInfo3.collider.GetComponent<Ghost>().TakeDamage(damage);

        }

        RaycastHit2D hitInfo4 = Physics2D.Raycast(transform.position, transform.up, distance, whatisground);
        if (hitInfo4.collider.CompareTag("ground"))
        {

            arrow.transform.gameObject.SetActive(false);
            Debug.Log("Se fue wey");
        }

        RaycastHit2D hitInfo5 = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemies);
        if (hitInfo5.collider.CompareTag("Boss"))
        {
            hitInfo5.collider.GetComponent<BossHealth>().TakeDamage(damage);
            arrow.transform.gameObject.SetActive(false);
            Debug.Log("Se fue wey");
        }

    }
}

