using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneLvl2 : MonoBehaviour {

	//public Rigidbody2D targetPoint;
	public Transform targetPoint;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 screenPoint = Camera.main.WorldToViewportPoint (targetPoint.position);
		bool onScreen = (screenPoint.x > 0 && screenPoint.y > 0 && screenPoint.x < 1 && screenPoint.y < 1);
		if(onScreen == true){
			LandscapeMovement.landSpeed = 0.0f;
			MapMovement.mapSpeed = 0.0f;
			Cowboy_Boss.activate = true;
			//Debug.Log ("Hit End Zone");
		}

	}

	/*void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			LandscapeMovement.landSpeed = 0.0f;
			MapMovement.mapSpeed = 0.0f;
			MechBoss.activate = true;
			Debug.Log ("Hit End Zone");
		}
	}*/
}
