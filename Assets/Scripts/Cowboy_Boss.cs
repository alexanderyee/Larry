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


	// Use this for initialization
	void Start () {
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
	}


	void Fire(GameObject obj){
		Instantiate (obj, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Bullet") {
			health--;
		} else if (col.tag == "Lightning") {
			health = health - 2;
		}
	}
}
