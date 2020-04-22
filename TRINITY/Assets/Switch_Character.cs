using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Switch_Character : MonoBehaviour {
    // References to Controlled game objects


    //public GameObject ninja, arquero, fighter;
    public GameObject[] chars;
    //public gameoobjects of personages hud
    public GameObject MarcoNinja1;
    public GameObject MarcoNinja2;
    public GameObject MarcoArcher1;
    public GameObject MarcoArcher2;
    public GameObject MarcoFighter1;
    public GameObject MarcoFighter2;
    private int ninja = 0, arquero = 1, fighter = 2;

    public Vector2 pos;

    int avatarActive = 0;




    // Start is called before the first frame update
    void Start()
    {
        /*chars[0] = ninja; chars[1] = arquero; chars[2] = fighter;
        ninja.gameObject.SetActive(true);
        arquero.gameObject.SetActive(false);
        fighter.gameObject.SetActive(false);
        */
        pos = transform.position;
        changeChar(ninja);
        MarcoNinja1.gameObject.SetActive(false);
        MarcoArcher1.gameObject.SetActive(true);
        MarcoFighter1.gameObject.SetActive(true);
        MarcoNinja2.gameObject.SetActive(true);
        MarcoArcher2.gameObject.SetActive(false);
        MarcoFighter2.gameObject.SetActive(false);
    }

    private void changeChar(int n)
    {
        //Task.Delay(500);
        if (n > 2) n = 0;
        chars[0].SetActive(false); chars[1].SetActive(false); chars[2].SetActive(false);
        chars[0].transform.position = pos;
        chars[n].transform.position = pos; chars[n].SetActive(true); 
        avatarActive = n;

        if (n == 0)
        {
            MarcoNinja1.gameObject.SetActive(false);
            MarcoNinja2.gameObject.SetActive(true);
            MarcoFighter1.gameObject.SetActive(true);
            MarcoFighter2.gameObject.SetActive(false);

        }
        else if (n==1)
        {
            MarcoArcher1.gameObject.SetActive(false);
            MarcoArcher2.gameObject.SetActive(true);
            MarcoNinja1.gameObject.SetActive(true);
            MarcoNinja2.gameObject.SetActive(false);


        }
        else
        {
            MarcoFighter1.gameObject.SetActive(false);
            MarcoFighter2.gameObject.SetActive(true);
            MarcoArcher1.gameObject.SetActive(true);
            MarcoArcher2.gameObject.SetActive(false);


        }

    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            changeChar(avatarActive + 1);
        }

    }
}
