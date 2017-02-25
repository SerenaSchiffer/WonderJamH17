using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeMoveableEnemy
{
    Soldier,
    Robot
}

public class MovableEnemy : MonoBehaviour {

    public TypeMoveableEnemy type;

    private GameObject destination;
    private Vector2 direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ReachDestination();
	}

    private void ReachDestination()
    {
        if (type == TypeMoveableEnemy.Soldier)
        {
            destination = GameObject.FindGameObjectWithTag("estinationSoldier");

            if (direction.magnitude < 0.1f)
            {
                direction = Vector2.zero;
            }
            else
            {
                AddVelocity(100);
            }
                
        }
        else if (type == TypeMoveableEnemy.Robot)
        {
            float minimalMagnitude;
            float magnitudePlayerSoldier;
            Vector2 distance;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            destination = players[0];
            
            distance = destination.transform.position - gameObject.transform.position;
            minimalMagnitude = distance.magnitude;

            foreach (GameObject player in players)
            {
                distance = player.transform.position - gameObject.transform.position;
                magnitudePlayerSoldier = distance.magnitude;

                if (minimalMagnitude > magnitudePlayerSoldier)
                {
                    minimalMagnitude = magnitudePlayerSoldier;
                    destination = player;
                }
            }

            AddVelocity(80);
        }
    }

    private void AddVelocity(float speed)
    {
        direction = destination.transform.position - gameObject.transform.position;
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed * Time.deltaTime;
    }

    private void shootPlayer()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
