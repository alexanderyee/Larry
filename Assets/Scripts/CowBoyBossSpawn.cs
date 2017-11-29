using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBoyBossSpawn : MonoBehaviour {


	public GameObject goonPrefabRoundOne;
	public GameObject goonPrefabRoundTwo;

	private GameObject newGoon;
	private bool spawnCheckRoundOne;
	private bool spawnCheckRoundTwo;

	// Use this for initialization
	void Start () {
		spawnCheckRoundOne = false;
		spawnCheckRoundTwo = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Cowboy_Boss.health == 20 && spawnCheckRoundOne == false) {
			SpawnGoonsRoundOne ();
			spawnCheckRoundOne = true;
		}
		if (Cowboy_Boss.health == 10 && spawnCheckRoundTwo == false) {
			SpawnGoonsRoundTwo ();
			spawnCheckRoundTwo = true;
		}
	}

	void SpawnGoonsRoundOne(){
		newGoon = Instantiate (goonPrefabRoundOne, new Vector3 (transform.position.x-2, transform.position.y+2), Quaternion.identity);
		newGoon = Instantiate (goonPrefabRoundOne, new Vector3 (transform.position.x-2, transform.position.y-2), Quaternion.identity);
		newGoon = Instantiate (goonPrefabRoundOne, new Vector3 (transform.position.x-2, transform.position.y), Quaternion.identity);
	}

	void SpawnGoonsRoundTwo(){
		newGoon = Instantiate (goonPrefabRoundTwo, new Vector3 (transform.position.x-2, transform.position.y+2), Quaternion.identity);
		newGoon = Instantiate (goonPrefabRoundTwo, new Vector3 (transform.position.x-2, transform.position.y-2), Quaternion.identity);
		newGoon = Instantiate (goonPrefabRoundTwo, new Vector3 (transform.position.x-2, transform.position.y), Quaternion.identity);
	}
}
