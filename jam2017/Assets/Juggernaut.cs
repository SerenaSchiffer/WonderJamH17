using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggernaut : MonoBehaviour {

    private float nextShot;
    private float spread = 35;

	// Use this for initialization
	void Start () {
        nextShot = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (nextShot == 0)
        {
            nextShot = 1.5f;
            
        }
        if (nextShot > 0)
        {
            nextShot -= Time.deltaTime;
        }
        if (nextShot < 0)
        {
            nextShot = 0;
        }
    }
}
