using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CowboyAI : MonoBehaviour {

	private float num;
	private float moveDelay = 100.0f;
	private float moveCheck = 100.0f;
	private float speed = 3.0f;
	private Rigidbody2D cowboy;

	// Use this for initialization
	void Start () {
		cowboy = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Cowboy_Boss.activate == true) {
			if (moveCheck == moveDelay) {
				num = Random.Range (-1, 2);
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
		}
	}
}
