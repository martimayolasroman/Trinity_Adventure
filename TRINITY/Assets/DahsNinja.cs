using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DahsNinja : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private float moveInput;
    public float cooldownTime = 2;
    private float nextDashTIme = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    private void Update()
    {

        moveInput = Input.GetAxis("Horizontal");
        if (direction == 0)
        {
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    direction = 1;
            //}
            //else if (Input.GetKeyDown(KeyCode.D))
            //{
            //    direction = 2;
            //}
            if (Time.time > nextDashTIme)
            {

            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(moveInput < 0)
                {
                    direction = 1;
                        nextDashTIme = Time.time + cooldownTime;
                    }
                    else if(moveInput >0)
                {
                    direction = 2;
                        nextDashTIme = Time.time + cooldownTime;
                    }

            }

            }

        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                gameObject.GetComponent<Animator>().SetBool("dash", false);

            }
            else
            {
                dashTime -= Time.deltaTime;
                gameObject.GetComponent<Animator>().SetBool("dash", true);

                

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;

                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;

                }
               
            }
        }

    }



    /* // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
          void Update()
       {

       }
       */
}
