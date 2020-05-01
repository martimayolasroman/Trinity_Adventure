using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PLAYMEN : MonoBehaviour
{

    public GameObject PLAYMENU;

    public void LEVEL1(string scenename)
    {
        Application.LoadLevel(scenename);
        
    }
    //    public void LEVEL2(string scenename)
    //    {
    //       // SceneManager.LoadScene("SceneName", LoadSceneMode.single);
    //    }
    //    public void LEVEL3(string scenename)
    //    {
    //        Application.LoadLevel(scenename);
    //    }
    //    public void BOSS(string scenename)
    //    {
    //        Application.LoadLevel(scenename);
    //    }
    public void exit(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
