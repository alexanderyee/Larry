using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 bullScreenPos = Camera.main.WorldToScreenPoint (this.transform.position);
		if (bullScreenPos.x >= Screen.width || bullScreenPos.x <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollision2dEnter(Collision2D collision){
		Destroy (gameObject);
	}
}
