using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoon : MonoBehaviour {

    public float dieDelay = 30;
    public bool hit = false;
	private int health;
	// Use this for initialization
	void Start () {
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (hit == true) dieDelay--;
        if (dieDelay == 0) Destroy(gameObject);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Bullet" && dieDelay == 30) {
			health--;
			/*Score.curScore += 100;
            hit = true;*/
			if (health <= 0) {
				Score.curScore += 100;
				hit = true;
			}
				
		} else if ((col.tag == "Lightning" && dieDelay == 30) || (col.tag == "Rifle" && dieDelay == 30)) {
			Score.curScore += 100;
            hit = true;
		}
	}
}
