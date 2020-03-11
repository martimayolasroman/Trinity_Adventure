using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Switch_Character : MonoBehaviour {
    // References to Controlled game objects


    //public GameObject ninja, arquero, fighter;
    public GameObject[] chars;
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
        
    }

    private void changeChar(int n)
    {
        //Task.Delay(500);
        if (n > 2) n = 0;
        chars[0].SetActive(false); chars[1].SetActive(false); chars[2].SetActive(false);
        chars[0].transform.position = pos;
        chars[n].transform.position = pos; chars[n].SetActive(true); 
        avatarActive = n;
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
