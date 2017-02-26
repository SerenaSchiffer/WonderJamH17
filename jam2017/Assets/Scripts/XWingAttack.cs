using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWingAttack : MonoBehaviour {

    private int pointsGot = 0;

	// Use this for initialization
	void Start () {
        float random = (float)Random.Range(0f, 360f);
        gameObject.transform.Rotate(0, 0, random);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPoints(int nbPoints)
    {
        pointsGot += nbPoints;
        Debug.Log(pointsGot);
    }

    public int GetPointsGot()
    {
        return pointsGot;
    }
}
