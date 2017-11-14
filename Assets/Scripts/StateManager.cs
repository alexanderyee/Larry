using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {
	public static bool gameOver;
	public static bool levelOneDone = false;
	public static bool levelTwoDone = false;
	public static bool levelThreeDone = false; 
	public GameObject popUp, winPopUp;
	public Canvas canvas;

	private GameObject message;
	private Vector2 position = new Vector2 (375, 270);





	// Use this for initialization
	void Start () {
		gameOver = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver == false && Health.currentHealth <= 0){
			EndGame ();
		}
		if (gameOver == true && Input.GetButtonDown ("Jump")) {
			gameOver = false;
			PlayerMovement.canPlay = true;
			TurnOffMsg ();
			Health.ResetHealth ();
			Score.ResetScore ();
			if (MechBoss.hp <= 0 && levelOneDone == true) {
				SceneManager.LoadScene ("2-1");
				levelOneDone = false;
			} else if (Cowboy_Boss.health <= 0 && levelTwoDone == true) {
				SceneManager.LoadScene ("3-1");
				levelTwoDone = false;
			} else if (EvilLarryBoss.health <= 0 && levelThreeDone == true) {
				levelThreeDone = false;
				Debug.Log ("Quitting App");
				Application.Quit ();
			} else {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
		if (gameOver == false && MechBoss.hp <= 0 && levelOneDone == true) {
			YouWin ();
			//levelOneDone = false;
		}
		if (gameOver == false && Cowboy_Boss.health <= 0 && levelTwoDone == true) {
			YouWin ();
			//levelTwoDone = false;
		}
		if (gameOver == false && EvilLarryBoss.health <= 0 && levelThreeDone == true) {
			YouWin ();
		}
	}

	void YouWin(){
		MapMovement.mapSpeed = 0;
		LandscapeMovement.landSpeed = 0;
		TurnOnWinMsg ();
		PlayerMovement.canPlay = false;
		PlayerMovement.inputX = 0f;
		PlayerMovement.inputY = 0f;
		gameOver = true;
	}

	void EndGame(){
		MapMovement.mapSpeed = 0;
		LandscapeMovement.landSpeed = 0;
		TurnOnMsg ();
		PlayerMovement.canPlay = false;
		PlayerMovement.inputX = 0f;
		PlayerMovement.inputY = 0f;
		gameOver = true;
	}

	void TurnOnWinMsg(){
		message = (GameObject)Instantiate (winPopUp, position, Quaternion.identity);
		message.transform.SetParent (canvas.transform);
	}

	void TurnOnMsg(){
		message = (GameObject)Instantiate (popUp, position, Quaternion.identity);
		message.transform.SetParent (canvas.transform);
	}

	void TurnOffMsg(){
		DestroyObject (message);
	}
}
