using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeMovement : MonoBehaviour {

	float mapSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += mapSpeed * Time.deltaTime * Vector3.left;
	}
}
