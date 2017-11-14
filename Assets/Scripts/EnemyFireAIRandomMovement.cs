using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireAIRandomMovement : MonoBehaviour {

    private int fireCounter;
    private int fireTime;
    private float num;
    private float moveDelay = 60f;
    private float moveCheck = 60f;
    private float speed = 3.0f;

    public Rigidbody2D bullet;
    public GameObject hero;

    //public Rigidbody2D bulletPrefab;
    //public Transform aimPoint;
    //public Transform shootPoint;
    //public float bulletSpeed = 300.0f;

    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .3f;
    private float volHighRange = .7f;
    private Rigidbody2D enemy;
    public float bulletSpeed;

    // Use this for initialization
    void Start()
    {
        fireCounter = 0;
        fireTime = 120;
        enemy = GetComponent<Rigidbody2D>();
        hero = GameObject.Find("Hero");

    }

    // Update is called once per frame
    void Update()
    {

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

                if (moveCheck == moveDelay)
                {
                    num = Random.Range(-1, 2);
                    Debug.Log(num);
                    if (num < 0)
                    {
                        enemy.velocity = transform.up * speed;
                    }
                    else if (num == 0)
                    {
                        enemy.velocity = new Vector2(0, 0);
                    }
                    else
                    {
                        enemy.velocity = transform.up * speed * (-1);
                    }
                    moveCheck = 0;
                }
                Vector3 pos = transform.position;
                
                pos.y = Mathf.Clamp(pos.y, -2.5f, 2.1f);
                transform.position = pos;
                moveCheck++;

            }
        }
    }

    void Fire(Rigidbody2D obj)
    {
        Vector3 dir = hero.transform.position - transform.position;
        dir = Vector3.Normalize(dir * bulletSpeed);
        Rigidbody2D firedBullet;
        if (dir.x < 0)
        {
            firedBullet = Instantiate(obj, transform.position, Quaternion.identity) as Rigidbody2D;
            firedBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
            firedBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed);
        }
    }

	/*void Fire(){
		Vector3 playerPos = new Vector3(aimPoint.position.x, aimPoint.position.y);
		Vector3 screenPos = Camera.main.ScreenToWorldPoint (new Vector3 (playerPos.x, playerPos.y, transform.position.z));

		Quaternion q = Quaternion.FromToRotation (Vector3.up, screenPos - transform.position);

		Rigidbody2D bullet;


		if (transform.localScale.x < 0) {

			bullet = Instantiate (bulletPrefab, new Vector3 (transform.position.x - shootPoint.localPosition.x, transform.position.y - shootPoint.localPosition.y, transform.position.z), q) as Rigidbody2D;
		} else {
			bullet = Instantiate (bulletPrefab, new Vector3 (transform.position.x + shootPoint.localPosition.x, transform.position.y + shootPoint.localPosition.y, transform.position.z), q) as Rigidbody2D;
		}
		bullet.GetComponent<Rigidbody2D> ().AddForce (bullet.transform.up * bulletSpeed);
		Debug.Log ("firing");
	}*/

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
}
