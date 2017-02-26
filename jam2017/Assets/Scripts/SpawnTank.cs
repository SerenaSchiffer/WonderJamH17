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
            StartCoroutine(FlashLogo());
            TimeBetweenTanks *= 0.95f;
            nextTank = TimeBetweenTanks;
        }
	}

    IEnumerator FlashLogo()
    {
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.3f);
            GetComponentInChildren<SpriteRenderer>().enabled = !GetComponentInChildren<SpriteRenderer>().enabled;
        }
        SpawnTanks();
    }
    void SpawnTanks()
    {
        GameObject tank = (GameObject)Instantiate(Resources.Load("Prefabs/Tank"));
        tank.transform.position = transform.position;
    }
}
