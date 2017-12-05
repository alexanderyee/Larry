using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLarryBoss : MonoBehaviour {

    public static int health;
	public Rigidbody2D bullet;
    public Rigidbody2D rocket;
	public GameObject hero;
	public int bulletSpeed;

    private float waveDelay;
    private float waveCounter;
    public bool hit = false;
    Animator anim;

    public static bool activate;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        health = 40;
        waveDelay = 60.0f;
        waveCounter = 60.0f;
        activate = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (activate == true)
        {

            if (waveCounter == waveDelay)
            {
                Fire(bullet);
                waveCounter = 0f;
            }
            else if (waveCounter == (waveDelay / 2))
            {
                Fire(rocket);
            }
            waveCounter = waveCounter + 1;
        }

        if (health < 1)
        {
            Destroy(gameObject);
			StateManager.levelThreeDone = true;
        }
        if (hit)
        {
            anim.SetTrigger("Hit");
            hit = false;
        }
        else
        {
            anim.SetTrigger("NotHit");
        }
    }
    /*void Fire(GameObject obj)
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }*/

	void Fire(Rigidbody2D obj){
		Vector3 dir = hero.transform.position - transform.position;
		dir = Vector3.Normalize(dir*bulletSpeed);
		Rigidbody2D firedBullet;

		Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        if (obj.tag == "Enemy")
        {
            rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180);
        }
        if (dir.x < -.4)
		{
			firedBullet = Instantiate(obj, transform.position, rotation) as Rigidbody2D;
			firedBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
			firedBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed);
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            health--;
            hit = true;

        }
        else if (col.tag == "Lightning")
        {
            health = health - 2;
            hit = true;

        }
    }

}
