using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{

    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")) { 

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime,0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }


        if (Input.GetKey("d"))
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(!Input.GetKey("a") && !Input.GetKey("d"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Animator>().SetBool("jump", true);
        }

        if (Input.GetKey("space") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
           
        }

        if (Input.GetKey("space") && Input.GetKey("d") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,300f));
            gameObject.GetComponent<Animator>().SetBool("jump", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey("space") && Input.GetKey("a") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
            gameObject.GetComponent<Animator>().SetBool("jump", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (!Input.GetKey("space") && !Input.GetKey("space"))
        {
            gameObject.GetComponent<Animator>().SetBool("jump", false);
        }






    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.transform.tag == "ground")
        {
            canJump = true;
        }

    }
}


