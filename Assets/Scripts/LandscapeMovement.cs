using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeMovement : MonoBehaviour {

	public static float landSpeed;
	// Use this for initialization
	void Start () {
		landSpeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += landSpeed * Time.deltaTime * Vector3.left;
	}
}
