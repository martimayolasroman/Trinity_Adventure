using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;
    public float delay = -0.1f;
    // Start is called before the first frame update
    void Start()
    {

        health = numOfHearts;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health > numOfHearts) { health = numOfHearts; }
        if (health == 0)
        {
            Die();
        }
        for (int i=0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else { hearts[i].sprite = EmptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else { hearts[i].enabled = false; }
        }
        
    }

    void Die()
    {
        
        gameObject.GetComponent<Animator>().SetBool("Die", true);
        //Restart the level 
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);

    }

    public void Damage(int dmg)
    {
        health -= dmg;
    }
}
