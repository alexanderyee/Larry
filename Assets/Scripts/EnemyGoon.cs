using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoon : MonoBehaviour {

    public float dieDelay = 30;
    public bool hit = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hit == true) dieDelay--;
        if (dieDelay == 0) Destroy(gameObject);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Bullet") {
			Score.curScore += 100;
			Debug.Log ("Enemy hit");
            hit = true;
		} else if (col.tag == "Lightning") {
			Score.curScore += 100;
			Debug.Log ("Enemy shocked");
            hit = true;
		}
	}
}
