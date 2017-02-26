using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int hp, damage, points;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            return points;
        }
        else return 0;
    }
}
