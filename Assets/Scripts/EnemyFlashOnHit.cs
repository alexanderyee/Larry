using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlashOnHit : MonoBehaviour {

    Animator anim;
    public EnemyGoon enemy;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        enemy =  GetComponent<EnemyGoon>();
	}
	
	// Update is called once per frame
	void Update () {
        if (((EnemyGoon) enemy).hit) anim.SetTrigger("Hit");
	}
}
