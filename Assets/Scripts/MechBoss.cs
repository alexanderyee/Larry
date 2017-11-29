using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBoss : MonoBehaviour
{

    public static int hp;
	public Rigidbody2D projPrefab;

    private float waveDelay;
    private float waveCounter;
    public static bool finalStage;
    private bool activateMovement;
    private Rigidbody2D mech;
    private float moveDelay;
    private float moveCheck;
    private float num;
	public float bulletSpeed;
	public int q;

    public static bool activate;
    public bool hit = false;
    Animator anim;


    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        hp = 20;
        waveDelay = 200.0f;
        waveCounter = 200.0f;
        activate = false;
        finalStage = false;
        activateMovement = false;
        mech = GetComponent<Rigidbody2D>();
        moveCheck = 75.0f;
        moveDelay = 75.0f;
    }

    // Update is called once per frame
    void Update()
    {


        if (activate == true)
        {
            //Debug.Log ("Boss Activated");
            //Debug.Log (waveCounter.ToString ());
            if (waveCounter >= waveDelay)
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(shootSound, vol);
                //Debug.Log ("Time to Fire");
				Fire(projPrefab, q);
				q++;
				Fire (projPrefab, q);
				q++;
				Fire (projPrefab, q);
				q++;
				Fire (projPrefab, q);
				q++;
				Fire (projPrefab, q);
				q=0;

                

				/*Fire(projPrefab2);
                Fire(projPrefab3);
                Fire(projPrefab4);
                Fire(projPrefab5);*/
                waveCounter = 0f;
            }
            waveCounter = waveCounter + 1;
        }
        if (hp < 1)
        {
            Destroy(gameObject);
            StateManager.levelOneDone = true;
        }
        if (hp <= 15 && finalStage == false)
        {
            waveDelay = 150;
        }
        if (hp <= 10 && finalStage == false)
        {
            waveDelay = 100;
        }
        if (hp <= 5 && finalStage == false)
        {
            waveDelay = 75;
            hp = 10;
            finalStage = true;
            activateMovement = true;
            Debug.Log("finalStage");
        }
        if (activateMovement == true)
        {
            if (moveCheck == moveDelay)
            {
                Move();
                moveCheck = 0;
            }
            moveCheck++;
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

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -5.8f, 5f);
        pos.y = Mathf.Clamp(pos.y, -2.5f, 2.4f);
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    /*void Fire(GameObject pews)
    {
        Instantiate(pews, transform.position, Quaternion.identity);
    }*/

	void Fire(Rigidbody2D obj, int turn){
		Vector3 dir;
		if (turn == 0) {
			dir = new Vector3(-8, 5);
		} else if (turn == 1) {
			dir = new Vector3 (-8, -5);
		} else if (turn == 2) {
			dir = new Vector3 (-8, 0);
		} else if (turn == 3) {
			dir = new Vector3 (-8, 2.5f);
		} else {
			dir = new Vector3 (-8, -2.5f);
		}
		Rigidbody2D firedBullet;
		dir = Vector3.Normalize (dir * bulletSpeed);

		firedBullet = Instantiate (obj, transform.position, Quaternion.identity) as Rigidbody2D;
		firedBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
		firedBullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed);
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            hp--;
            Debug.Log("Hit Boss");
            hit = true;
        }
        else if (col.tag == "Lightning")
        {
            hp = hp - 2;
            Debug.Log("Hit Boss");
            hit = true;
        }

    }

    //Randomly rolls number and moves mech accordly up or down
    void Move()
    {
        num = Random.Range(-25, 26);
        if (num > 0)
        {
            mech.velocity = transform.up * Random.Range(20,35) * Time.deltaTime;
        }
        else
        {
            mech.velocity = transform.up * Random.Range(20, 35) * Time.deltaTime * -1;
        }
    }
}