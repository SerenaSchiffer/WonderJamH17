using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTank : MonoBehaviour {

    public float TimeBetweenTanks;
    private float nextTank;
	// Use this for initialization
	void Start () {
        nextTank = TimeBetweenTanks;
	}
	
	// Update is called once per frame
	void Update () {
        nextTank -= Time.deltaTime;
        if(nextTank <= 0)
        {
            SpawnTanks();
            TimeBetweenTanks *= 0.95f;
            nextTank = TimeBetweenTanks;
        }
	}

    void SpawnTanks()
    {
        GameObject tank = (GameObject)Instantiate(Resources.Load("Prefabs/Tank"));
        tank.transform.position = transform.position;
    }
}
