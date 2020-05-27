using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class CooldownBar : MonoBehaviour

    {

    public GameObject bar;
    public int time;
    // Start is called before the first frame update
    void Start()
    {

        cooldown();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void cooldown()
    {
        LeanTween.scaleX(bar, 1, time);

    }
}
