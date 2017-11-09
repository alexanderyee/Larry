using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLarryAi : MonoBehaviour {
    private float num;
    public static float inputY;
    private float moveDelay = 100.0f;
    private float moveCheck = 100.0f;
    private float speed = 4.0f;
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
        if (EvilLarryBoss.activate == true)
        {
            if (onEnter)
            {
                Vector3 tempPos = transform.position;
                tempPos.y = hero.transform.position.y;
                transform.position = tempPos;
                onEnter = false;
            }
            inputY = Input.GetAxisRaw("Vertical");

            if (inputY != 0)
            {
                evilLarry.velocity = transform.up * speed * inputY;
            }
            else
            {
                evilLarry.velocity = new Vector2(0, 0);
            }
            

            Vector3 pos = transform.position;

            pos.x = Mathf.Clamp(pos.x, -5.8f, 5f);
            pos.y = Mathf.Clamp(pos.y, -4f, 2.4f);
            transform.position = pos;
            moveCheck++;
        }
    }
}
