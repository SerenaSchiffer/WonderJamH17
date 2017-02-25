using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDismiss : MonoBehaviour {

    public float timeToDie;
    private float actualTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (actualTime <= timeToDie)
        {
            //Debug.Log(actualTime);
            actualTime += Time.deltaTime;
        }
        else
        {
            //Destroy(gameObject);
        }
	}
}
