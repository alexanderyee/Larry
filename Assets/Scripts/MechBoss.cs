using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBoss : MonoBehaviour {

	public static int hp;
	public GameObject projPrefab;
	public GameObject projPrefab2;
	public GameObject projPrefab3;
	public GameObject projPrefab4;
	public GameObject projPrefab5;

	private float waveDelay;
	private float waveCounter;

	public static bool activate;


    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1f;

    // Use this for initialization
    void Start () {
		hp = 20;
		waveDelay = 200.0f;
		waveCounter = 200.0f;
		activate = false;
	}
	
	// Update is called once per frame
	void Update () {
    

		if (activate == true) {
			//Debug.Log ("Boss Activated");
			//Debug.Log (waveCounter.ToString ());
			if (waveCounter == waveDelay) {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(shootSound, vol);
                //Debug.Log ("Time to Fire");
                Fire (projPrefab);
				Fire (projPrefab2);
				Fire (projPrefab3);
				Fire (projPrefab4);
				Fire (projPrefab5);
				waveCounter = 0f;
			}
			waveCounter = waveCounter + 1;
		}
		if (hp < 1) {
			Destroy (gameObject);
		}
	}

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void Fire(GameObject pews){
		Instantiate (pews, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Bullet") {
			hp--;
			Debug.Log ("Hit Boss");
		} else if (col.tag == "Lightning") {
			hp = hp - 2;
		}
	}
}
