using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	public Rigidbody2D bulletPrefab;
	public float attackSpeed = 0.2f;
	public float bulletSpeed = 600.0f;
	public Transform shootPoint;

	private float coolDown;

    public static bool canPlay;
    public AudioClip shootSound;
    public AudioClip lightningSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1f;
    // Use this for initialization
    void Start () {
        coolDown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= coolDown) {
			if (Input.GetMouseButton (0)) {
				Fire ();
			}
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump") || Input.GetMouseButton(0))
            {
                print("wat");
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(shootSound, vol);
                Fire();
            }
        }
	}

	void Fire(){
		Vector3 mousePos = Input.mousePosition;
		Vector3 screenPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, transform.position.z));

		Quaternion q = Quaternion.FromToRotation (Vector3.up, screenPos - transform.position);

		Rigidbody2D bullet;

		if (transform.localScale.x < 0) {

			bullet = Instantiate (bulletPrefab, new Vector3 (transform.position.x - shootPoint.localPosition.x, transform.position.y - shootPoint.localPosition.y, transform.position.z), q) as Rigidbody2D;
            print("<0");
		} else {
			bullet = Instantiate (bulletPrefab, new Vector3 (transform.position.x + shootPoint.localPosition.x, transform.position.y + shootPoint.localPosition.y, transform.position.z), q) as Rigidbody2D;
            print(">0");
		}

		bullet.GetComponent<Rigidbody2D> ().AddForce (bullet.transform.up * bulletSpeed);
		coolDown = Time.time + attackSpeed;
	}
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

}
