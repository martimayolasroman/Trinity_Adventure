using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SkeletonAttack : MonoBehaviour
{
    public AudioClip atackClip;
    private AudioSource audioPlayer;
    //private ninja life;
    int dmg = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        // life = GameObject.FindGameObjectWithTag("Players").GetComponent<ninja>();
        //archer = GameObject.FindGameObjectWithTag("Player").GetComponent<Arquero>();
        //boxer = GameObject.FindGameObjectWithTag("Player").GetComponent<Fighter>();
        audioPlayer = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Players"))
        {
           
            collision.SendMessageUpwards("Damage", dmg);
            audioPlayer.clip = atackClip;
            audioPlayer.Play();

        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
