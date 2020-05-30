using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private bool jump;
    public float cooldownTime = 2;
    private float nextDashTIme = 0;

    //cooldown
    public GameObject bar;
    public int time;
    public float movementVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        jump = false;
    }

    private void Update()
    {
        if (jump == false)
        {

            if (Input.GetKey("d"))
            {

                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementVelocity * Time.deltaTime, 0);

            }
            if (Input.GetKey("a"))
            {

                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-movementVelocity * Time.deltaTime, 0);

            }
            if (Time.time > nextDashTIme)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    jump = true;
                    nextDashTIme = Time.time + cooldownTime;
                }
            }


        }
        else
        {
            if (dashTime <= 0)
            {
                jump = false; ;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                gameObject.GetComponent<Animator>().SetBool("dash", false);

            }
            else
            {
                dashTime -= Time.deltaTime;
                gameObject.GetComponent<Animator>().SetBool("dash", true);
                cooldownfighter();


                if (jump == true)
                {
                    rb.velocity = Vector2.up * dashSpeed;

                }

            }
        }

    }

    void cooldownfighter()
    {
        LeanTween.scaleX(bar, 0, 0);
        // Transform.localScale.x = 0f;
        LeanTween.scaleX(bar, 1, time);

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