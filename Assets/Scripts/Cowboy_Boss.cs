using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy_Boss : MonoBehaviour {

	public static int health;
	public GameObject bullet;
	public GameObject rocket;

	private float waveDelay;
	private float waveCounter;

	public static bool activate;

    public bool hit = false;
    Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        health = 30;
		waveDelay = 150.0f;
		waveCounter = 150.0f;
		activate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (activate == true) {

			if (waveCounter == waveDelay) {
				Fire (bullet);
				waveCounter = 0f;
			} else if (waveCounter == (waveDelay / 2)) {
				Fire (rocket);
			}
			waveCounter = waveCounter + 1;
		}

		if (health < 1) {
			Destroy (gameObject);
			HeroHit.levelTwoDone = true;
		}
        if (hit)
        {
            anim.SetTrigger("Hit");
            hit = false;
        }
        else
        {
            anim.SetTrigger("NotHit");
        }
    }


	void Fire(GameObject obj){
		Instantiate (obj, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Bullet") {
			health--;
            hit = true;
            Debug.Log("hit cowboy");

        }
        else if (col.tag == "Lightning") {
			health = health - 2;
            hit = true;

            Debug.Log("hit cowboy");

        }
    }
}
