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
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsEnemies);
        if (hitInfo.collider.CompareTag("Enemy"))
        {
            hitInfo.collider.GetComponent<Enemy_behaviour>().TakeDamage(damage);
            hitInfo.collider.GetComponent<Ghost>().TakeDamage(damage);
            hitInfo.collider.GetComponent<BeeFollowPlayer>().TakeDamage(damage);
        }
    }
}
