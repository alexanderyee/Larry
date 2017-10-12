using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public GameObject projPrefab;
	public GameObject lightningPrefab;

	private List<GameObject> projectiles = new List<GameObject>();
	private float projVel;

	// Use this for initialization
	void Start () {
		projVel = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {


		transform.position += (Input.GetAxisRaw ("Horizontal") * speed * Vector3.right * Time.deltaTime);
		transform.position += (Input.GetAxisRaw ("Vertical") * speed * Vector3.up * Time.deltaTime);

		Vector3 pos = transform.position;

		pos.x = Mathf.Clamp (pos.x, -5.8f, 5);
		pos.y = Mathf.Clamp (pos.y, -4, 3);
		transform.position = pos;
	


		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
			GameObject bullet = (GameObject)Instantiate (projPrefab, transform.position, Quaternion.identity);
			projectiles.Add (bullet);
		}

		if (Input.GetButtonDown ("Fire2") || Input.GetButtonDown("Fire3")) {
			GameObject lightning = (GameObject)Instantiate (lightningPrefab, transform.position, Quaternion.identity);
			projectiles.Add (lightning);
		}


		for (int i = 0; i < projectiles.Count; i++) {
			GameObject goBullet = projectiles [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (1, 0) * Time.deltaTime * projVel);

				Vector3 bullScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bullScreenPos.x >= Screen.width || bullScreenPos.x <= 0) {
					DestroyObject (goBullet);
					projectiles.Remove (goBullet);
				}
			}
		}
	}

	/*void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Rock") {
			transform.position += 0 * Vector3.right;
			Debug.Log ("Hit rock");
		}
	}*/

}
