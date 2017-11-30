using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {


	private List<string> weaponList = new List<string>();
	public static string curWeapon;
	private int i;

	public Sprite pistol;
	public Sprite rifle;
	public Sprite shotgun;

	// Use this for initialization
	void Start () {
		weaponList.Add ("Pistol");
		weaponList.Add ("Rifle");
		weaponList.Add ("Shotgun");
		int i = 0;
		curWeapon = weaponList [i];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            i--;
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            i++;
        }
        i = i % weaponList.Count;
		//print (i);
		print(curWeapon);
		curWeapon = weaponList[i];
		ChangeSprite (curWeapon);

    }

	void ChangeSprite(string s){
		if (s == "Pistol") {
			this.GetComponent<SpriteRenderer> ().sprite = pistol;
			//gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("Hero", typeof(Sprite)) as Sprite;
			Debug.Log("Pistol Sprite");
		} else if (s == "Rifle") {
			this.GetComponent<SpriteRenderer> ().sprite = rifle;
			//gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("HeroRifle", typeof(Sprite)) as Sprite;
			Debug.Log ("Rifle Sprite");
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = shotgun;
			//gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("HeroShotgun", typeof(Sprite)) as Sprite;
			Debug.Log("Shotgun Sprite");
		}
	}
}
