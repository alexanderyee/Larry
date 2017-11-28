using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CowboyAI : MonoBehaviour {

	public Rigidbody2D grenade;

	private float num;
	private float moveDelay = 75.0f;
	private float moveCheck = 75.0f;
	private float speed = 5.0f;
	private Rigidbody2D cowboy;
	private int nadeCheck;
	private int nadeCounter;

	// Use this for initialization
	void Start () {
		cowboy = GetComponent<Rigidbody2D> ();
		nadeCheck = 0;
		nadeCounter = 115;
	}
	
	// Update is called once per frame
	void Update () {
		if (Cowboy_Boss.activate == true) {
			if (moveCheck == moveDelay) {
				num = Random.Range (-25, 26);
				Debug.Log (num);
				if (num < 0) {
					cowboy.velocity = transform.up * speed;
				} else if (num == 0) {
					cowboy.velocity = new Vector2 (0, 0);
				}
				else {
					cowboy.velocity = transform.up * speed * (-1);
				}
				moveCheck = 0;
			}
			Vector3 pos = transform.position;

			pos.x = Mathf.Clamp (pos.x, -5.8f, 5f);
			pos.y = Mathf.Clamp (pos.y, -2.5f, 2.4f);
			transform.position = pos;
			moveCheck++;

			if (nadeCheck == nadeCounter) {
				ThrowGrenade ();
				nadeCheck = 0;
			}
			nadeCheck++;
				
		}
	}

	void ThrowGrenade(){
		Vector3 throwDir = new Vector3 (-1, 1);
		Rigidbody2D nade;
		nade = Instantiate (grenade, transform.position, Quaternion.identity);
		nade.GetComponent<Rigidbody2D> ().AddForce (throwDir * 160);
	}
}
