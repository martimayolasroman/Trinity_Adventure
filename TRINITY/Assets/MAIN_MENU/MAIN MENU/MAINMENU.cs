using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAINMENU : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip botons;
    private AudioSource audioPlay;
    public GameObject PauseUII;

    public void play(string scenename)
    {
        audioPlay = GetComponent<AudioSource>();
        Application.LoadLevel(scenename);
    }
public void savegame()
    {
        audioPlay.clip = botons;
        audioPlay.Play();
    }
    public void options()
    {
        audioPlay.clip = botons;
        audioPlay.Play();
    }
    public void credits()
    {
        audioPlay.clip = botons;
        audioPlay.Play();
    }

  
    public void exit()
    {
        audioPlay.clip = botons;
        audioPlay.Play();
        Application.Quit();
    }
}
