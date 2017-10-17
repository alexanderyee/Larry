using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireAI : MonoBehaviour {


	private int fireCounter;
	private int fireTime;

	public GameObject bullet;


	// Use this for initialization
	void Start () {
		fireCounter = 0;
		fireTime = 120;
	}
	
	// Update is called once per frame
	void Update () {
		if (HeroHit.gameOver == false) {
			fireCounter++;
			if (fireCounter == fireTime) {
				Fire (bullet);
				fireCounter = 0;
			}
		}
	}

	void Fire(GameObject obj){
		Instantiate (obj, transform.position, Quaternion.identity);
	}
}
