using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDespawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (MechBoss.finalStage == true)
        {
            Destroy(gameObject);
            print("rock destroy");
        }
    }
}
