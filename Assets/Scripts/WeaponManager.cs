using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {


	private List<string> weaponList = new List<string>();
	public static string curWeapon;
	private int i;

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
		if (Input.GetKey (KeyCode.Q) && i > 0) {
			i--;
			curWeapon = weaponList [i];
		} else if (Input.GetKey (KeyCode.E) && i < 2) {
			i++;
			curWeapon = weaponList [i];
		} else if (Input.GetKey (KeyCode.Q) && i == 0) {
			i = 2;
			curWeapon = weaponList [i];
		} else if (Input.GetKey (KeyCode.E) && i == 2) {
			i = 0;
			curWeapon = weaponList [i];
		}
			
			
	}
}
