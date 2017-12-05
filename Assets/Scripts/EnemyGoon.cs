using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoon : MonoBehaviour {

    public float dieDelay = 30;
    public bool hit = false;
	private int health;

	public static bool contact = false;
	// Use this for initialization
	void Start () {
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (hit == true) {
			dieDelay--;
			//Flash ();
		}
        if (dieDelay == 0) Destroy(gameObject);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Bullet" && dieDelay == 30) {
			health--;
			contact = true;
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

	/*void animFlash(){
		Debug.Log ("Pls Flash");
		Sprite curSprite = this.GetComponent<SpriteRenderer> ().sprite;
		for (int i = 0; i < 21; i++) {
			this.GetComponent<SpriteRenderer> ().sprite = null;
			if (i == 20) {
				this.GetComponent<SpriteRenderer> ().sprite = curSprite;
			}
		}
	}*/
}
