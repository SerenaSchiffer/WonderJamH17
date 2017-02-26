using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    Transform center;

	// Use this for initialization
	void Start () {
        center = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Feet")
        {
            Vector2 toCenter = center.position - other.transform.position;
            other.GetComponentInParent<Rigidbody2D>().velocity += toCenter;
            other.GetComponentInParent<PlayableChar>().falling = true;
        }
                
               
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Feet")
        {
            Vector2 toCenter = center.position - other.transform.position;
            Debug.Log(toCenter.x + " " + toCenter.y);
            other.GetComponentInParent<Rigidbody2D>().velocity = toCenter.normalized;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Feet")
        {
            other.GetComponentInParent<PlayableChar>().falling = false;
        }


    }

}
