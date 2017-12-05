using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireAI : MonoBehaviour {


	private int fireCounter;
	private int fireTime;

	public Rigidbody2D bullet;
    public GameObject hero; 

	public Sprite restSprite;
	public Sprite fireSprite;

    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .3f;
    private float volHighRange = .7f;
    public float bulletSpeed;

	private bool isFiring;
	private bool contact = false;
	int w;
	bool beginCount;

	private Sprite curSprite;

	private int flashCounter = 0;
    // Use this for initialization
    void Start () {
		fireCounter = 0;
		fireTime = 80;
        hero = GameObject.Find("Hero");
		this.GetComponent<SpriteRenderer> ().sprite = restSprite;
		isFiring = false;
		w = 0;
		beginCount = false;
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
					//AnimateFire ();
					isFiring = true;
                    fireCounter = 0;
                }
            }
        }

		if (isFiring == true) {
			AnimateFire ();
			beginCount = true;
			isFiring = false;
		}
		if (beginCount == true) {
			w++;
		}

		if (w == 40) {
			this.GetComponent<SpriteRenderer> ().sprite = restSprite;
			w = 0;
			beginCount = false;
		}
		if (contact == true) {
			//w = 0;
			//animFlash ();
			//EnemyGoon.contact = false;

			Debug.Log ("Pls Flash");
			if (flashCounter == 0) {
				
				curSprite = this.GetComponent<SpriteRenderer> ().sprite;
				this.GetComponent<SpriteRenderer> ().sprite = null;
			}

			flashCounter++;
			/*for (int i = 0; i < 21; i++) {
				this.GetComponent<SpriteRenderer> ().sprite = null;
				if (i == 20) {
					this.GetComponent<SpriteRenderer> ().sprite = curSprite;
				}
			}*/
		}

		if (flashCounter > 0) {
			if (flashCounter >= 14) {
				this.GetComponent<SpriteRenderer> ().sprite = curSprite;
				contact = false;
				flashCounter = 0;
			} else if (flashCounter >= 10) {
				this.GetComponent<SpriteRenderer> ().sprite = null;
				Debug.Log ("second flash");
			} else if(flashCounter >= 6){
				this.GetComponent<SpriteRenderer> ().sprite = curSprite;
			}
		}
			
    }

	void Fire(Rigidbody2D obj){
        Vector3 dir = hero.transform.position - transform.position;
        dir = Vector3.Normalize(dir*bulletSpeed);
        Rigidbody2D firedBullet;
        if (dir.x < -.4)
        {
            firedBullet = Instantiate(obj, transform.position, Quaternion.identity) as Rigidbody2D;
            firedBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
            firedBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed);
        }
    }


	void AnimateFire(){
		this.GetComponent<SpriteRenderer> ().sprite = fireSprite;
	}

	/*void animFlash(){
		Debug.Log ("Pls Flash");
		Sprite curSprite = this.GetComponent<SpriteRenderer> ().sprite;
		for (int i = 0; i < 21; i++) {
			this.GetComponent<SpriteRenderer> ().sprite = null;
			if (i == 20) {
				this.GetComponent<SpriteRenderer> ().sprite = curSprite;
			}
		}
	}*/


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Bullet") {
			contact = true;
		}
	}
}
