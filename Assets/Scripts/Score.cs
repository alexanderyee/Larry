using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int curScore = 0;

	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = curScore.ToString ();
	}

	void Update(){
		scoreText.text = "Score:" + curScore.ToString ();
	}

	public static void ResetScore(){
		curScore = 0;
	}
}
