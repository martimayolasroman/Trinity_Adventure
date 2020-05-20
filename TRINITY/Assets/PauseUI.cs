using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{

    public GameObject PauseUII;
    private bool paused = false;
    private GameObject HUDD;

    void Start()
    {
        HUDD = GameObject.FindGameObjectWithTag("HUD");
        DontDestroyOnLoad(this.gameObject); // no es destruira .
        PauseUII.SetActive(!paused);

    }

    void Update()
    {

      


        if ((Input.GetKeyDown(KeyCode.P))) {

            paused = !paused;
        }
        if (paused)
        {

            PauseUII.SetActive(true);
            Time.timeScale = 0;
            HUDD.SetActive(false);

        }
        if (!paused)
        {

            PauseUII.SetActive(false);
            Time.timeScale = 1;
            HUDD.SetActive(true);
        }
    }

    public void Resume()
    {


        paused = false;
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenU(string scenename)
    {
        Application.LoadLevel(scenename);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Se salio wey");
    }
}
