using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public static int health = 10;

	public Text healthText;

	void Start () {
		healthText.text = health.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "HP:" + health.ToString ();
	}

	public static void ResetHealth(){
		health = 10;
	}
}
