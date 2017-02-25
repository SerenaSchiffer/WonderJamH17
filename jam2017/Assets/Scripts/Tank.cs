using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    Rigidbody2D tankBody;
    public int speed;

	// Use this for initialization
	void Start () {
        tankBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        tankBody.velocity = new Vector2(speed, 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //fonction de kill
            Destroy(other.gameObject);
        }
    }
}
