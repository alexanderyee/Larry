using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireAI : MonoBehaviour {


	private int fireCounter;
	private int fireTime;

	public GameObject bullet;

    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .3f;
    private float volHighRange = .7f;

    // Use this for initialization
    void Start () {
		fireCounter = 0;
		fireTime = 80;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = (screenPoint.x > 0 && screenPoint.y > 0 && screenPoint.x < 1 && screenPoint.y < 1);
        if (onScreen == true)
        {

			if (StateManager.gameOver == false)
            {
                fireCounter++;
                if (fireCounter == fireTime)
                {
                    float vol = Random.Range(volLowRange, volHighRange);
                    source.PlayOneShot(shootSound, vol);
                    Fire(bullet);
                    fireCounter = 0;
                }
            }
        }
    }

	void Fire(GameObject obj){
		Instantiate (obj, transform.position, Quaternion.identity);
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
}
