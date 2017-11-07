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

    public GameObject bullet;

    public AudioClip shootSound;
    private AudioSource source;
    private float volLowRange = .3f;
    private float volHighRange = .7f;
    private Rigidbody2D enemy;


    // Use this for initialization
    void Start()
    {
        fireCounter = 0;
        fireTime = 120;
        enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = (screenPoint.x > 0 && screenPoint.y > 0 && screenPoint.x < 1 && screenPoint.y < 1);
        if (onScreen == true)
        {

            if (HeroHit.gameOver == false)
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
                
                pos.y = Mathf.Clamp(pos.y, -2.5f, 2.2f);
                transform.position = pos;
                moveCheck++;

            }
        }
    }

    void Fire(GameObject obj)
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
}
