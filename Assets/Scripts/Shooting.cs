using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	public Rigidbody2D bulletPrefab;
	public Rigidbody2D lightningPrefab;
	public Rigidbody2D rifleBulletPrefab;
	public float attackSpeed;
	public float bulletSpeed = 600.0f;
	public Transform shootPoint;
	public string weaponUsed;

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

        //print("Cooldown: " + coolDown);
        //print("Time.time: " + Time.time);
        if (Time.time >= coolDown) {
			if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump") || Input.GetMouseButton(0)) && PlayerMovement.canPlay == true)
            {
				weaponUsed = WeaponManager.curWeapon;
                
				if (weaponUsed == "Pistol") {
					attackSpeed = 0.3f;
					Fire (bulletPrefab);
				} else if (weaponUsed == "Shotgun") {
					attackSpeed = 1.2f;
					FireShotgun (bulletPrefab);
				} else if (weaponUsed == "Rifle") {
					attackSpeed = 0.8f;
					Fire (rifleBulletPrefab);
				}
					


                //Fire();
            }
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

	void Fire(Rigidbody2D obj){

        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(shootSound, vol);
        Vector3 mousePos = Input.mousePosition;
		Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

		//Quaternion q = Quaternion.FromToRotation (Vector3.up, screenPos - transform.position);

		Rigidbody2D bullet;
        Vector3 shootPos;
		if (transform.localScale.x < 0) {

            shootPos = new Vector3 (transform.position.x - shootPoint.localPosition.x, transform.position.y - shootPoint.localPosition.y, transform.position.z);
		} else {
            shootPos = new Vector3(transform.position.x + shootPoint.localPosition.x, transform.position.y + shootPoint.localPosition.y, transform.position.z);
		}
        Vector3 bulletDir = screenPos - shootPoint.position;
        bulletDir.y = bulletDir.y - .115f; // fine tuning for shooting at mouse
        // fix for shooting close to mouse LMAO
        /*if (bulletDir.x < .5)
        {
            // mouse is too close to player. just shoot straight.
            bulletDir = Vector3.right;
        }*/
        /*else
        {*/
            bulletDir.x = bulletDir.x * 1000000;
            bulletDir.y = bulletDir.y * 1000000;
        //}
        bulletDir.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg);
		bullet = Instantiate(obj, shootPoint.position, rotation) as Rigidbody2D;

        bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
        bullet.GetComponent<Rigidbody2D> ().AddForce(bulletDir * bulletSpeed);

        coolDown = Time.time + attackSpeed;
	}

	void FireShotgun(Rigidbody2D obj){
			float vol = Random.Range(volLowRange, volHighRange);
			source.PlayOneShot(shootSound, vol);
			Vector3 mousePos = Input.mousePosition;
			Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);


			Rigidbody2D bullet;
			Vector3 shootPos;
			if (transform.localScale.x < 0) {

				shootPos = new Vector3 (transform.position.x - shootPoint.localPosition.x, transform.position.y - shootPoint.localPosition.y, transform.position.z);
			} else {
				shootPos = new Vector3(transform.position.x + shootPoint.localPosition.x, transform.position.y + shootPoint.localPosition.y, transform.position.z);
			}
			Vector3 bulletDir = screenPos - shootPoint.position;
			bulletDir.y = bulletDir.y - .115f; // fine tuning for shooting at mouse

			bulletDir.x = bulletDir.x * 1000000;
			bulletDir.y = bulletDir.y * 1000000;

			bulletDir.Normalize();
			Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg);

			bullet = Instantiate(obj, shootPoint.position, rotation) as Rigidbody2D;
			bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
			bullet.GetComponent<Rigidbody2D> ().AddForce(bulletDir * bulletSpeed);

			Vector3 bulletDirTemp = bulletDir;
			bulletDir = new Vector3 (bulletDirTemp.x - 0.2f, bulletDirTemp.y - 0.1f);
			bulletDir.x = bulletDir.x * 1000000;
			bulletDir.y = bulletDir.y * 1000000;
			bulletDir.Normalize();
			bullet = Instantiate(obj, shootPoint.position, rotation) as Rigidbody2D;
			bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
			bullet.GetComponent<Rigidbody2D> ().AddForce(bulletDir * bulletSpeed);

			bulletDirTemp = bulletDir;
			bulletDir = new Vector3 (bulletDirTemp.x - 0.2f, bulletDirTemp.y + 0.1f);
			bulletDir.x = bulletDir.x * 1000000;
			bulletDir.y = bulletDir.y * 1000000;
			bulletDir.Normalize();
			bullet = Instantiate(obj, shootPoint.position, rotation) as Rigidbody2D;
			bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
			bullet.GetComponent<Rigidbody2D> ().AddForce(bulletDir * bulletSpeed);

			bulletDirTemp = bulletDir;
			bulletDir = new Vector3 (bulletDirTemp.x - 0.2f, bulletDirTemp.y + 0.3f);
			bulletDir.x = bulletDir.x * 1000000;
			bulletDir.y = bulletDir.y * 1000000;
			bulletDir.Normalize();
			bullet = Instantiate(obj, shootPoint.position, rotation) as Rigidbody2D;
			bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
			bullet.GetComponent<Rigidbody2D> ().AddForce(bulletDir * bulletSpeed);

			bulletDirTemp = bulletDir;
			bulletDir = new Vector3 (bulletDirTemp.x - 0.2f, bulletDirTemp.y - 0.3f);
			bulletDir.x = bulletDir.x * 1000000;
			bulletDir.y = bulletDir.y * 1000000;
			bulletDir.Normalize();
			bullet = Instantiate(obj, shootPoint.position, rotation) as Rigidbody2D;
			bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
			bullet.GetComponent<Rigidbody2D> ().AddForce(bulletDir * bulletSpeed);



			coolDown = Time.time + attackSpeed;
	}



    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

}
