using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {


    public static int cooldown = 0;
    public static bool abilityReady = true;
    //public Text cooldownText;
    public Slider abilitySlider;


    void Start()
    {
        abilitySlider.value = 120;
    }

    // Update is called once per frame
    void Update()
    {
        abilitySlider.value = Mathf.Abs(120 - cooldown);

        if (cooldown == 0)
        {
            abilityReady = true;
        }
        else { cooldown--; }
        if (abilityReady == true)
        {

        }
        else
        {

        }

    }

}
