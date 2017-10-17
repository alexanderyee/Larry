using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {


    public static int cooldown = 60;
    public static bool abilityReady = true;
    public Text cooldownText;

    void Start()
    {
        cooldownText.text = cooldown.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown == 0)
        {
            abilityReady = true;
        }
        else { cooldown--; }
        if (abilityReady == true)
        {
            cooldownText.text = "Ability: READY";
        }
        else
        {
            cooldownText.text = "Ability:" + cooldown.ToString();
        }

    }

}
