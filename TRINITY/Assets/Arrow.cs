using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    public float distance;
    public LayerMask whatIsEnemies;



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


        }
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemies);

        if (hitInfo2.collider.CompareTag("SKELETON"))
        {
            //hitInfo.collider.GetComponent<Enemy_behaviour>().TakeDamage(damage);

            hitInfo2.collider.GetComponent<Enemy_behaviour>().TakeDamage(damage);


        }

        RaycastHit2D hitInfo3 = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemies);

        if (hitInfo3.collider.CompareTag("Enemy"))
        {


            hitInfo3.collider.GetComponent<Ghost>().TakeDamage(damage);

        }

        if (hitInfo1.collider.CompareTag("ground"))
        {
            //Si colisiona conta el terra destruir arrow
            //Object.Destroy();

        }

    }
}