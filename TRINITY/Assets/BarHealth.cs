using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHealth : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update
  
        public void SetmaxHeath(int health)
    {

        slider.maxValue = health;
        slider.value = health;

    }
    public void SetHealth(int health)
    {

        slider.value = health;

    }
}
