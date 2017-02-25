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
    private GameObject playerToShoot;
    private Vector2 direction;

    private float nextShot = 0;
    private bool isNear = false;
    private bool isShooting = false;
    private float spreadShootRobot = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ReachDestination();

        if (isShooting && nextShot == 0)
            shootPlayer(playerToShoot);
        else if (nextShot > 0)
            nextShot -= Time.deltaTime;
        else if (nextShot < 0)
            nextShot = 0;
	}

    private void ReachDestination()
    {
        if (type == TypeMoveableEnemy.Soldier)
        {
            destination = GameObject.FindGameObjectWithTag("DestinationSoldier");
            direction = GetDistance(destination);

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
            {
                direction = GetDistance(destination);
                AddVelocity(80);
            }
        }
    }

    private void AddVelocity(float speed)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed * Time.deltaTime;
    }

    private void shootPlayer(GameObject other)
    {
        Vector2 direction;
        Transform projectilePosition = gameObject.transform;
        GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/Bullet"));

        if (type == TypeMoveableEnemy.Soldier)
            nextShot = 0.75f;
        else
            nextShot = 0.35f;

        bullet.transform.position = transform.position;
        direction = GetDistance(other);

        if (type == TypeMoveableEnemy.Robot)
        {
            float random = Random.Range(-spreadShootRobot, spreadShootRobot);
            direction = Quaternion.AngleAxis(random, Vector3.forward) * direction;
        }

        bullet.GetComponent<Rigidbody2D>().velocity = direction * 5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AddVelocity(0);
            isNear = true;
            isShooting = true;
            playerToShoot = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isNear = false;
            isShooting = false;
            playerToShoot = null;
        }
            
    }

    Vector2 GetDistance(GameObject other)
    {
        return other.transform.position - gameObject.transform.position;
    }
}
