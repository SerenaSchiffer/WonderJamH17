using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampDownUp : MonoBehaviour {

    public float timeToDescend;
    private int pointsGot = 0;
    private float actualTime;
    float descendValue;

    GameObject stamp;
    GameObject denied;

    // Use this for initialization
    void Start () {
        actualTime = 0;
        
        stamp = (GameObject)gameObject.transform.GetChild(0).gameObject;
        denied = (GameObject)gameObject.transform.GetChild(1).gameObject;

        descendValue = (float)(stamp.transform.position.y - denied.transform.position.y) / (timeToDescend / Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
         if(actualTime<timeToDescend && stamp.transform.position.y > (denied.transform.position.y+1.34))
        {
            actualTime += Time.deltaTime;
            Vector2 nouvellePosition = new Vector2(stamp.transform.position.x, stamp.transform.position.y-descendValue);
            stamp.transform.position = nouvellePosition;
        }
        else
        {
            Vector2 nouvellePosition = new Vector2(stamp.transform.position.x, denied.transform.position.y+1.34f);
            stamp.transform.position = nouvellePosition;
            denied.GetComponent<SpriteRenderer>().enabled = true;
            stamp.GetComponent<FadeOut>().enabled = true;
            denied.GetComponent<FadeOut>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Enemy")
        {
            int damage = other.GetComponentInParent<EnemyScript>().hp;
            int points = other.GetComponentInParent<EnemyScript>().Damage(damage);

            if (points > 0)
            {
                Destroy(other.transform.parent.gameObject);
                pointsGot = points;
            }
        }
    }

    public int GetPointsGot()
    {
        return pointsGot;
    }
}
