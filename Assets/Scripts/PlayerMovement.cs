using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public static float inputX, inputY;
	public GameObject projPrefab;
	public GameObject lightningPrefab;
	private Rigidbody2D PlayerObject;
	public static bool canPlay;
    public AudioClip shootSound;
    public AudioClip lightningSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1f;
    // Use this for initialization
    void Start () {
		PlayerObject = GetComponent<Rigidbody2D> ();
		canPlay = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (canPlay == true) {
			

			//inputX = Input.GetAxisRaw ("Horizontal");
			inputY = Input.GetAxisRaw ("Vertical");

			if (inputX != 0 || inputY != 0) {
				PlayerObject.velocity = transform.up * speed * inputY + transform.right * speed * inputX;
			} else {
				PlayerObject.velocity = new Vector2 (0, 0);
			}
			//transform.position += (Input.GetAxisRaw ("Horizontal") * speed * Vector3.right * Time.deltaTime);
			//transform.position += (Input.GetAxisRaw ("Vertical") * speed * Vector3.up * Time.deltaTime);

			Vector3 pos = transform.position;

			pos.x = Mathf.Clamp (pos.x, -5.8f, 5f);
			pos.y = Mathf.Clamp (pos.y, -4f, 2.4f);
			transform.position = pos;
            

            if (Input.GetButtonDown("Fire2"))
            {
                if (Cooldown.abilityReady)
                {
                    Cooldown.cooldown = 120;
                    Cooldown.abilityReady = false;
                    float vol = Random.Range(volLowRange, volHighRange);
                    source.PlayOneShot(lightningSound, vol);
                    Fire(lightningPrefab);

                }
            }
		}


	}

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Fire(GameObject obj){
		Instantiate (obj, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "EnemyBullet") {

		} else if (col.tag == "Rock") {
			PlayerObject.velocity = new Vector2 (0, 0);
			Debug.Log ("Hitting Rock");
		}
			
	}

}
