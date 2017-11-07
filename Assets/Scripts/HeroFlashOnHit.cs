using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlashOnHit : MonoBehaviour {

    Animator anim;
    public HeroHit hero;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        hero = GetComponent<HeroHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hero.hit)
        {
            anim.SetTrigger("Hit");
            hero.hit = false;

        } else
        {
            anim.SetTrigger("NotHit");
        }

    }
}
