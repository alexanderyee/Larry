using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireAI : MonoBehaviour {


	private int fireCounter;
	private int fireTime;

	public Rigidbody2D bullet;
    public GameObject hero; 

    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .3f;
    private float volHighRange = .7f;
    public float bulletSpeed;
    // Use this for initialization
    void Start () {
		fireCounter = 0;
		fireTime = 80;
        hero = GameObject.Find("Hero");
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

	void Fire(Rigidbody2D obj){
        Vector3 dir = hero.transform.position - transform.position;
        dir = Vector3.Normalize(dir*bulletSpeed);
        Rigidbody2D firedBullet;
        if (dir.x < 0)
        {
            firedBullet = Instantiate(obj, transform.position, Quaternion.identity) as Rigidbody2D;
            firedBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
            firedBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed);
        }
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
}
