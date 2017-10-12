using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoon : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Bullet") {
			Debug.Log ("Enemy hit");
			Destroy (gameObject);
		} else if (col.tag == "Lightning") {
			Debug.Log ("Enemy shocked");
			Destroy (gameObject);
		}
	}
}
