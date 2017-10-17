using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour {

	public static float mapSpeed;
	// Use this for initialization
	void Start () {
		mapSpeed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += mapSpeed * Time.deltaTime * Vector3.left;
	}
}
