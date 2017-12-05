using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {


	private List<string> weaponList = new List<string>();
	private List<Sprite> pistolAnim = new List<Sprite> ();
	private List<Sprite> rifleAnim = new List<Sprite> ();
	private List<Sprite> shotgunAnim = new List<Sprite> ();
	private Sprite curSprite;

	public static string curWeapon;
	private int i;
	private int w;

	public Sprite pistol;
	public Sprite pistolRun1;
	public Sprite pistolRun2;
	public Sprite rifle;
	public Sprite rifleRun1;
	public Sprite rifleRun2;
	public Sprite shotgun;
	public Sprite shotgunRun1;
	public Sprite shotgunRun2;

	private int animCounter;
	private int animDelay;

	private int flashCounter = 0;
	private bool contact = false;

	// Use this for initialization
	void Start () {
		weaponList.Add ("Pistol");
		weaponList.Add ("Rifle");
		weaponList.Add ("Shotgun");

		pistolAnim.Add (pistol);
		pistolAnim.Add (pistolRun1);
		pistolAnim.Add (pistolRun2);
		rifleAnim.Add (rifle);
		rifleAnim.Add (rifleRun1);
		rifleAnim.Add (rifleRun2);
		shotgunAnim.Add (shotgun);
		shotgunAnim.Add (shotgunRun1);
		shotgunAnim.Add (shotgunRun2);

		i = 0;
		w = 0;

		curWeapon = weaponList [i];
		animCounter = 0;
		animDelay = 15;
	}
	
	// Update is called once per frame
	void Update () {
		//while (PlayerMovement.canPlay == true) {
			
		if (Input.GetKeyDown (KeyCode.Q)) {
			i--;
		} else if (Input.GetKeyDown (KeyCode.E)) {
			i++;
		}
		i = i % weaponList.Count;
		//print (i);
		//print (curWeapon);
		curWeapon = weaponList [i];
		//ChangeSprite (curWeapon);
		if (animCounter == animDelay) {
			w++;
			animCounter = 0;
			if (w > 2) {
				w = 0;
			}
		}
		ChangeSprite (curWeapon, w);
		animCounter++;

		if (contact == true) {
			Debug.Log ("Pls Flash");
			if (flashCounter == 0) {

				curSprite = this.GetComponent<SpriteRenderer> ().sprite;
				this.GetComponent<SpriteRenderer> ().sprite = null;
			}

			flashCounter++;
		}

		if (flashCounter > 0) {
			if (flashCounter >= 14) {
				this.GetComponent<SpriteRenderer> ().sprite = curSprite;
				contact = false;
				flashCounter = 0;
			} else if (flashCounter >= 10) {
				this.GetComponent<SpriteRenderer> ().sprite = null;
				Debug.Log ("second flash");
			} else if (flashCounter >= 6) {
				this.GetComponent<SpriteRenderer> ().sprite = curSprite;
			}
		}


	//	}
    }

	void ChangeSprite(string s, int j){
		if (s == "Pistol") {
			//this.GetComponent<SpriteRenderer> ().sprite = pistol;
			//gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Hero", typeof(Sprite)) as Sprite;
			//Debug.Log("Pistol Sprite");
			AnimateSet (pistolAnim, j);
		} else if (s == "Rifle") {
			//this.GetComponent<SpriteRenderer> ().sprite = rifle;
			//gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("HeroRifle", typeof(Sprite)) as Sprite;
			//Debug.Log ("Rifle Sprite");
			AnimateSet (rifleAnim, j);
		} else {
			//this.GetComponent<SpriteRenderer> ().sprite = shotgun;
			//gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("HeroShotgun", typeof(Sprite)) as Sprite;
			//Debug.Log("Shotgun Sprite");
			AnimateSet (shotgunAnim, j);
		}
	}

	void AnimateSet(List<Sprite> sprites, int i){
		this.GetComponent<SpriteRenderer> ().sprite = sprites [i];
		//Debug.Log (i);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Enemy" || col.tag == "Rocket" || col.tag == "EnemyBullet" || col.tag == "Grenade") {
			contact = true;
		}
	}
		
}
