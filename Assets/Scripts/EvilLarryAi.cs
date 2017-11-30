using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLarryAi : MonoBehaviour {

    private float num;
    private float moveDelay = 25.0f;
    private float moveCheck = 25.0f;
    private float speed = 8.0f;
    private Rigidbody2D evilLarry;
    

	public Vector3 initialPos;
    public bool onEnter = true;
    public GameObject hero;




    // Use this for initialization
    void Start () {
        evilLarry = GetComponent<Rigidbody2D>();
        hero = GameObject.Find("Hero");
	}
	
	// Update is called once per frame
	void Update () {
        if (EvilLarryBoss.activate == true){
			if (moveCheck == moveDelay) {
				int num = Random.Range (-25, 26);
				if (num > 0 && num < 12) {
					evilLarry.velocity = transform.up * speed + transform.right * speed;
				} else if (num < 0 && num > (-12)) {
					evilLarry.velocity = transform.up * speed * -1 / 2 + transform.right * speed * -1 / 2;
				}else if(num >=12){
					evilLarry.velocity = transform.up * speed * 1 / 2 + transform.right * speed * 1 / 2;
				} else {
					evilLarry.velocity = transform.up * speed * (-1) + transform.right * speed * (-1);
				}

				/*int num2 = Random.Range (-25, 26);
				if (num2 > 0 && num2 < 12) {
					evilLarry.velocity = transform.right * speed;
				} else if (num2 < 0 && num2 > (-12)) {
					evilLarry.velocity = transform.right * speed * -1 / 2;
				}else if(num2 >=12){
					evilLarry.velocity = transform.right * speed * 1 / 2;
				} else {
					evilLarry.velocity = transform.right * speed * (-1);
				}*/
				moveCheck = 0;

			}

			Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, 2f, 5f);
            pos.y = Mathf.Clamp(pos.y, -4f, 2.4f);
			transform.position = pos;
            moveCheck++;
        }
    }
}
