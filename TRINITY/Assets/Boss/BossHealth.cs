using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 3;
    public int currentHealth;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

    public BarHealth healthbar;

    void Start()
    {
        currentHealth = health;
        healthbar.SetmaxHeath(health);
    }

    public void TakeDamage(int damage)
    {
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Debug.Log(damage);
        Debug.Log(health);
        health -= damage;
        Debug.Log("damage TaKEN !");

        if (health <= 10)
            	{
            		GetComponent<Animator>().SetBool("IsEnraged", true);
            	}

            if (health <= 0)
        {
            Die();
        }

    }

    //   public void TakeDamage(int damage)
    //{
    //	if (isInvulnerable)
    //		return;

    //	health -= damage;
    //       healthbar.SetHealth(health);

    //	if (health <= 2)
    //	{
    //		GetComponent<Animator>().SetBool("IsEnraged", true);
    //	}

    //	if (health <= 0)
    //	{
    //		Die();
    //	}
    //}

    void Die()
    {
       // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
