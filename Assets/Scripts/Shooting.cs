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
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump") || Input.GetMouseButton(0))
            {
                Fire();
            }
        }
	}

	void Fire(){

        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(shootSound, vol);
        Vector3 mousePos = Input.mousePosition;
		Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

		Quaternion q = Quaternion.FromToRotation (Vector3.up, screenPos - transform.position);

		Rigidbody2D bullet;
        Vector3 shootPos;
		if (transform.localScale.x < 0) {

            shootPos = new Vector3 (transform.position.x - shootPoint.localPosition.x, transform.position.y - shootPoint.localPosition.y, transform.position.z);
           // print("<0");
		} else {
            shootPos = new Vector3(transform.position.x + shootPoint.localPosition.x, transform.position.y + shootPoint.localPosition.y, transform.position.z);
            //print(">0");
		}
        Vector3 bulletDir = screenPos - shootPoint.position;
        bulletDir.y = bulletDir.y - .115f; // fine tuning for shooting at mouse
        // fix for shooting close to mouse LMAO
        if (bulletDir.x < .5)
        {
            // mouse is too close to player. just shoot straight.
            bulletDir = Vector3.right;
        }
        else
        {
            bulletDir.x = bulletDir.x * 1000000;
            bulletDir.y = bulletDir.y * 1000000;
        }
        bulletDir.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg);
        bullet = Instantiate(bulletPrefab, shootPoint.position, rotation) as Rigidbody2D;
        print(bulletDir.x + ", " + bulletDir.y);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
        bullet.GetComponent<Rigidbody2D> ().AddForce(bulletDir * bulletSpeed);
        print(bullet.GetComponent<Rigidbody2D>().velocity);

        coolDown = Time.time + attackSpeed;
	}
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

}
