﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Arquero : MonoBehaviour
{
    bool isatak = false;
    bool animationjump = false;
    bool canJump;

    //   ATTACK

    private float TimeAttack;
    public float StartTimeAttack;
    public GameObject arrow;

    // LIFE

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;
    public float delay = 0f;
    private Shake shake;
    public AudioClip jumpClip;
    public AudioClip dmgPlayer;
    private AudioSource audioPlayer;






    // Start is called before the first frame update
    void Start()
    {
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        audioPlayer = GetComponent<AudioSource>();
        arrow.SetActive(false);
        //GetComponent<ScriptName>().miau();
    }

    // Update is called once per frame
    void Update()
    {

        GetComponentInParent<Switch_Character>().pos = new Vector2(transform.position.x, transform.position.y);
        //GetComponentInParent<Transform>().transform.position = transform.position;

        if (Input.mousePosition.x - 215 > GameObject.FindGameObjectWithTag("CoordenadesPlayers").transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("a"))
        {

            if (isatak == false)
            {
                if (Input.mousePosition.x - 215 > GameObject.FindGameObjectWithTag("CoordenadesPlayers").transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
                    gameObject.GetComponent<Animator>().SetBool("moving", true);
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else {

                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
                    gameObject.GetComponent<Animator>().SetBool("moving", true);
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            if (isatak == true)
            {
                if (Input.mousePosition.x - 215 > GameObject.FindGameObjectWithTag("CoordenadesPlayers").transform.position.x)
                {


                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    gameObject.GetComponent<Animator>().SetBool("moving", false); //posar animacio menters corre i ataka

                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    gameObject.GetComponent<Animator>().SetBool("moving", false); //posar animacio menters corre i ataka

                }


            }
        }


        if (Input.GetKey("d"))
        {
            if (isatak == false)
            {
                if (Input.mousePosition.x - 215 > GameObject.FindGameObjectWithTag("CoordenadesPlayers").transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
                    gameObject.GetComponent<Animator>().SetBool("moving", true);
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
                    gameObject.GetComponent<Animator>().SetBool("moving", true);
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            if (isatak == true)
            {
                if (Input.mousePosition.x - 215 > GameObject.FindGameObjectWithTag("CoordenadesPlayers").transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
                    gameObject.GetComponent<Animator>().SetBool("moving", false);
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
                    gameObject.GetComponent<Animator>().SetBool("moving", false);
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;





                }
            }
        }

            if (!Input.GetKey("a") && !Input.GetKey("d"))
            {
                gameObject.GetComponent<Animator>().SetBool("moving", false);
                gameObject.GetComponent<Rigidbody2D>().velocity= (new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y));

            }
        
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 7f)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(7f, gameObject.GetComponent<Rigidbody2D>().velocity.y));
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < -7f)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(-7f, gameObject.GetComponent<Rigidbody2D>().velocity.y));
        }

        if (Input.GetKey("space") && canJump)
            {

                canJump = false;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
                animationjump = true;
                audioPlayer.clip = jumpClip;
                audioPlayer.Play();
            }


            if (animationjump) { gameObject.GetComponent<Animator>().SetBool("jump", true); }
            else gameObject.GetComponent<Animator>().SetBool("jump", false);

            if (isatak) { gameObject.GetComponent<Animator>().SetBool("attack", true); arrow.SetActive(true);
            }
            else gameObject.GetComponent<Animator>().SetBool("attack", false);




            /*  if (Input.GetKey("space") && Input.GetKey("d") && canJump)
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
              }*/


            if (animationjump == true && isatak == true)
            {

                animationjump = false;
            }



            if (TimeAttack <= 0) //Then you can attack
            {



                if (Input.GetKey(KeyCode.Mouse0))
                {
                    isatak = true;

                    // gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    TimeAttack = StartTimeAttack;
                    

                }

            }
            else
            {
                TimeAttack -= Time.deltaTime;
            }

            if (!Input.GetKey(KeyCode.Mouse0))
            {

                isatak = false;


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


        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.transform.tag == "ground")
            {

                canJump = true;
                animationjump = false;
            }

        }

        void Die()
        {

            gameObject.GetComponent<Animator>().SetBool("Die", true);
            //Restart the level 
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            //Destroy(gameObject);

            //Cambiar de personatge automaticament

            //switchCh.changeChar(1);

        }

        public void Damage(int dmg)
        {
           // shake.CamShake();
            health -= dmg;
        audioPlayer.clip = dmgPlayer;
        audioPlayer.Play();
        }


    }



