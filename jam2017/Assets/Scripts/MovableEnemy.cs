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
    public GameObject destination;

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
            Vector2 direction = destination.transform.position - gameObject.transform.position;

            
        }
    }
}
