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

        LeanTween.scaleX(bar, 1, time);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
