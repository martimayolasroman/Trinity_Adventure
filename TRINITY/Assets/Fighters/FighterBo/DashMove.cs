﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    private void Update()
    {
        if (direction == 0){
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    direction = 1;
            //}
            //else if (Input.GetKeyDown(KeyCode.D))
            //{
            //    direction = 2;
            //}
           if (Input.GetKeyDown(KeyCode.E))
            {
                direction = 3;

            }
            //else if (Input.GetKeyDown(KeyCode.S))
            //{
            //    direction = 4;
            //}

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
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;

                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;

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
