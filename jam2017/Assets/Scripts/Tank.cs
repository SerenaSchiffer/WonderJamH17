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
        if(tankBody.position.x > 13)
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //fonction de kill
            other.gameObject.GetComponentInParent<PlayableChar>().SetHp(-15);
            if (other.gameObject.GetComponentInParent<Rigidbody2D>())
            {
                //disable player controller
                //add velocity
                //coroutine in 0.1f second
                
                if (other.gameObject.transform.position.y < gameObject.transform.position.y)
                {
                    other.gameObject.transform.parent.transform.position += new Vector3(0, -1, 0);
                }
                else
                {
                    other.gameObject.transform.parent.transform.position += new Vector3(0, 1,0);
                }
            }
            //Destroy(other.transform.parent.gameObject);
        }
    }
}
