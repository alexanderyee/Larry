using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigProjectile : MonoBehaviour {

	public static float velX;
	public static float velY;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
		velX = -8f;
		velY = 0f;
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (velX, velY);

		Vector3 bullScreenPos = Camera.main.WorldToScreenPoint (this.transform.position);
		if (bullScreenPos.x >= Screen.width || bullScreenPos.x <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Rock") {
			Destroy (gameObject);
		} else if (col.tag == "Player") {
			Destroy (gameObject);
		}
	}

	public void SetVector(float x, float y){
		velX = x;
		velY = y;

		Debug.Log (velX.ToString ());
		Debug.Log (velY.ToString ());
	}
}
