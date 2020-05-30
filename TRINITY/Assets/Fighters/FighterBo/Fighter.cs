


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Fighter : MonoBehaviour
{
    bool isatak = false;
    bool animationjump = false;
    bool canJump;
    bool jumpatak = false;

    private float jumpTimer;
    private float startTime;
    private bool isJumping;


    public float movementVelocity;
    private float facing;

    //   ATTACK

    private float TimeAttack;
    public float StartTimeAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public Collider2D attackTrigguerLeft;
    public Collider2D attackTrigguerRight;
    public AudioClip jumpClip;
    public AudioClip atackClip;
    private AudioSource audioPlayer;
    // LIFE

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;
    public float delay = 0;
    private Shake shake;


    // Start is called before the first frame update
    public void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        //switchCh = gameObject.GetComponent<Switch_Character>();
        audioPlayer = GetComponent<AudioSource>();


        health = numOfHearts;
        //GetComponent<ScriptName>().miau();
        attackTrigguerLeft.enabled = false;
        attackTrigguerRight.enabled = false;
        //GetComponent<ScriptName>().miau();
    }

    // Update is called once per frame
    public void Update()
    {
        GetComponentInParent<Switch_Character>().pos = new Vector2(transform.position.x, transform.position.y);
        //GetComponentInParent<Transform>().transform.position = transform.position;
        if (Input.GetKey("a") && !Input.GetKey("e"))
        {

            if (isatak == false)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(-movementVelocity * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (isatak == true)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(-movementVelocity * Time.deltaTime, 0));
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                gameObject.GetComponent<Animator>().SetBool("moving", false); //posar animacio menters corre i ataka

            }
        }


        if (Input.GetKey("d") && !Input.GetKey("e"))
        {
            if (isatak == false)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(movementVelocity * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (isatak == true)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(movementVelocity * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", false);

            }
        }

        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y));
        }

        if (Input.GetKey("space") && canJump)
        {


            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
            animationjump = true;
            audioPlayer.clip = jumpClip;
            audioPlayer.Play();

            canJump = false;
            isJumping = true;
            jumpTimer = 0.25f;

        }

        if (animationjump && !jumpatak) { gameObject.GetComponent<Animator>().SetBool("jump", true); }
        else gameObject.GetComponent<Animator>().SetBool("jump", false);

        if (isatak && !jumpatak) { gameObject.GetComponent<Animator>().SetBool("attack", true); }
        else gameObject.GetComponent<Animator>().SetBool("attack", false);

        if (jumpatak) { gameObject.GetComponent<Animator>().SetBool("jumpatak", true); }
        else gameObject.GetComponent<Animator>().SetBool("jumpatak", false);
        /* if (Input.GetKey("space") && Input.GetKey("d") && canJump)
         {
             canJump = false;
             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
             gameObject.GetComponent<Animator>().SetBool("jump", true);
             gameObject.GetComponent<SpriteRenderer>().flipX = false;
         }

         if (Input.GetKey("space") && Input.GetKey("a") && canJump)
         {
             canJump = false;
             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
             gameObject.GetComponent<Animator>().SetBool("jump", true);
             gameObject.GetComponent<SpriteRenderer>().flipX = true;
         }*/

        if (animationjump == true && isatak == true)
        {

            animationjump = false;
        }



        if (TimeAttack <= 0) //Then you can attack
        {

            if (!canJump && Input.GetKey(KeyCode.Mouse0))
            {
                jumpatak = true;

                attackTrigguerLeft.enabled = true;
                attackTrigguerRight.enabled = true;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                isatak = true;


                attackTrigguerLeft.enabled = true;
                attackTrigguerRight.enabled = true;
                audioPlayer.clip = atackClip;
                audioPlayer.Play();


                // gameObject.GetComponent<SpriteRenderer>().flipX = false;



            }
            TimeAttack = StartTimeAttack;
        }
        else
        {
            TimeAttack -= Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.Mouse0))
        {

            isatak = false;
            jumpatak = false;
            attackTrigguerLeft.enabled = false;
            attackTrigguerRight.enabled = false;



        }
        if (!canJump && !jumpatak)
        {
            animationjump = true;
        }

        //health

        if (health > numOfHearts) { health = numOfHearts; }
        if (health == 0)
        {
            Die();
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else { hearts[i].enabled = false; }
        }

        if (isJumping)
        {

            if (Input.GetKey("d"))
            {

                facing = 1;

            }
            if (Input.GetKey("a"))
            {

                facing = -1;

            }
            if (!Input.GetKey("a") && !Input.GetKey("d"))
            {

                facing = 0;
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(15f * facing, 17f));
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0)
            {
                isJumping = false;
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "ground")
        {

            canJump = true;
            animationjump = false;
            jumpatak = false;
        }

    }



    void Die()
    {

        //gameObject.GetComponent<Animator>().SetBool("Die", true);
        //Restart the level 
        // Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        //Destroy(gameObject);

        //Cambiar de personatge automaticament

        //switchCh.changeChar(1);

    }

    public void Damage(int dmg)
    {
        shake.CamShake();
        health -= dmg;
    }

}
