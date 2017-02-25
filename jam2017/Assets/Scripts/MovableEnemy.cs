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
    private bool isNear = false;
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

            distance = GetDistance(destination);
            minimalMagnitude = distance.magnitude;

            foreach (GameObject player in players)
            {
                distance = GetDistance(player);
                magnitudePlayerSoldier = distance.magnitude;

                if (minimalMagnitude > magnitudePlayerSoldier)
                {
                    minimalMagnitude = magnitudePlayerSoldier;
                    destination = player;
                }
            }

            if (!isNear)
                AddVelocity(80);
            else
                Debug.Log("debug IsNear");
        }
    }

    private void AddVelocity(float speed)
    {
        direction = destination.transform.position - gameObject.transform.position;
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed * Time.deltaTime;
    }

    private void shootPlayer(GameObject other)
    {
        Vector2 projectileForce;
        Transform projectilePosition = gameObject.transform;
        GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/Bullet"));


        bullet.transform.position = transform.position;
        projectileForce = GetDistance(other);
        bullet.GetComponent<Rigidbody2D>().velocity = projectileForce * 5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shootPlayer(other.gameObject);
            AddVelocity(0);
            isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            isNear = false;
    }

    Vector2 GetDistance(GameObject other)
    {
        return other.transform.position - gameObject.transform.position;
    }
}
