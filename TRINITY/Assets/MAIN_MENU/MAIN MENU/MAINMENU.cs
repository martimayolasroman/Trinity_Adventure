using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAINMENU : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip botons;
    public GameObject PauseUII;

    public void play(string scenename)
    {
 
        Application.LoadLevel(scenename);
    }
public void savegame()
    {

    }
    public void options(string scenename)
    {
        Application.LoadLevel(scenename);

    }
    public void credits()
    {

    }

  
    public void exit()
    {

        Application.Quit();
    }
}
