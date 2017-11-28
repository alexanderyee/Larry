using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour {

	private int shieldMax;
	private int shieldTime;
	private bool shieldOn;
	private GameObject shield;

	public GameObject shieldPrefab;

	// Use this for initialization
	void Start () {
		shieldMax = 75;
		shieldTime = 0;
		shieldOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire3")) {
			if (Cooldown.abilityReady) {
				Cooldown.cooldown = 120;
				Cooldown.abilityReady = false;
				shieldOn = true;
				Shield ();
			}
		}
		if (shieldOn) {
			shieldTime++;
		}
		if (shieldOn && shieldTime == shieldMax) {
			Destroy (shield);
			shieldTime = 0;
		}
	}

	void Shield(){
		shield = Instantiate (shieldPrefab, new Vector3(transform.position.x+0.4f, transform.position.y-0.2f), Quaternion.identity);
		shield.transform.parent = gameObject.transform;
	}
		
}
