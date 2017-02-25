using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {

    public float timeToGrow;
    private float actualTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(actualTime<=timeToGrow)
        {
            actualTime += Time.deltaTime;
            gameObject.transform.localScale = new Vector3((float)(gameObject.transform.localScale.x + 0.1), (float)(gameObject.transform.localScale.y + 0.1), gameObject.transform.localScale.z);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
