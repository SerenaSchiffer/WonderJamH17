using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeMoveableEnemy
{
    Soldier,
    Robot,
    Juggernaut,
    Sniper
}

public class MovableEnemy : MonoBehaviour {

    public TypeMoveableEnemy type;
    public float nextShot;
    public float spreadShoot;

    private GameObject destination;
    private GameObject playerToShoot;
    private Vector2 direction;
    private SelectedSpawnPosition ssp;

    private bool isNear = false;
    private bool isShooting = false;
    private float decNextShot = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ReachDestination();
        if (isShooting && decNextShot == 0)
        {
            decNextShot = nextShot;
            shootPlayer(playerToShoot);
        }
        else if (decNextShot > 0)
            decNextShot -= Time.deltaTime;
        else if (decNextShot < 0)
            decNextShot = 0;
    }

    private void ReachDestination()
    {
        if (type == TypeMoveableEnemy.Soldier)
        {
            destination = GameObject.FindGameObjectWithTag("DestinationSoldier");
            GoToDestination();
        }
        else if (type == TypeMoveableEnemy.Robot)
        {
            FollowPlayer();
        }
        else if (type == TypeMoveableEnemy.Juggernaut || type == TypeMoveableEnemy.Sniper)
        {
            isShooting = true;
            destination = GetSelectedSpawnPositionObject();
            GoToDestination();
            playerToShoot = GameObject.FindGameObjectWithTag("DestinationSoldier");
        }
        else if (type == TypeMoveableEnemy.Sniper)
        {
            isShooting = true;
            destination = GetSelectedSpawnPositionObject();
            GoToDestination();
            playerToShoot = GetRandomPlayer();
        }
    }

    private GameObject GetRandomPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        int indiceRandom = UnityEngine.Random.Range(0, 4);
        Debug.Log(indiceRandom);
        return new GameObject();
    }

    private void GoToDestination()
    {
        //this.destination = destination;
        direction = GetDistance(this.destination);

        if (direction.magnitude < 0.1f)
        {
            direction = Vector2.zero;
            AddVelocity(0);
        }
        else
        {
            AddVelocity(100);
        }
    }

    private void FollowPlayer()
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

    private GameObject GetSelectedSpawnPositionObject()
    {
        GameObject destination;

        switch (ssp)
        {
            case SelectedSpawnPosition.Left:
                destination = GameObject.Find("LeftDestination");
                break;

            case SelectedSpawnPosition.Right:
                destination = GameObject.Find("RightDestination");
                break;

            default:
                destination = GameObject.Find("BottomDestination");
                break;
        }

        if (type == TypeMoveableEnemy.Sniper)
        {
            destination.transform.position += new Vector3(0, 3);
            return destination;
        }
        else
            return destination;
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

        bullet.transform.position = transform.position;
        direction = GetDistance(other);

        if (type == TypeMoveableEnemy.Robot || type == TypeMoveableEnemy.Juggernaut)
        {
            float random = UnityEngine.Random.Range(-spreadShoot, spreadShoot);
            direction = Quaternion.AngleAxis(random, Vector3.forward) * direction;
        }

        bullet.GetComponent<Rigidbody2D>().velocity = direction * 1.5f;
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

    public void SetSelectedSpawnPosition(SelectedSpawnPosition ssp)
    {
        this.ssp = ssp;
    }
}
