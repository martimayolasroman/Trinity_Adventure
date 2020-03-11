using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Switch_Character : MonoBehaviour {
    // References to Controlled game objects


    public GameObject ninja, arquero, fighter;

    int wichAvatarIsOn = 0;




    // Start is called before the first frame update
    void Start()
    {

        ninja.gameObject.SetActive(true);
        arquero.gameObject.SetActive(false);
        fighter.gameObject.SetActive(false);

    }





    public void SwitchCharcter()
    {

        switch (wichAvatarIsOn)
        {

            case 0:
                wichAvatarIsOn = 1;
                ninja.gameObject.SetActive(false);
                arquero.gameObject.SetActive(true);
                fighter.gameObject.SetActive(false);
               Task.Delay(500);
                break;
            case 1:
                wichAvatarIsOn = 2;
                ninja.gameObject.SetActive(false);
                arquero.gameObject.SetActive(false);
                fighter.gameObject.SetActive(true);
                Task.Delay(500);
                break;
            case 2:
                wichAvatarIsOn = 0;
                ninja.gameObject.SetActive(true);
                arquero.gameObject.SetActive(false);
                fighter.gameObject.SetActive(false);
                Task.Delay(500);
                break;
                

        }




    }




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            SwitchCharcter();


        }

    }
}
