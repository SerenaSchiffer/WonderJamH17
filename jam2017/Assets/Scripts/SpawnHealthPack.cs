using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealthPack : MonoBehaviour {

    public float spawningRate;
    float nextHP;

	// Use this for initialization
	void Start () {
        nextHP = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if(nextHP <= 0)
        {
            nextHP = spawningRate;
            SpawnPack();
        }
        else 
        {
            nextHP -= Time.deltaTime;
        }
	}

    void SpawnPack()
    {
        for(int i = 0;i < 100;i++)
        {
            int randomHp = Random.Range(0, 9);
            GameObject healthPack = transform.GetChild(randomHp).gameObject;
            if(!healthPack.activeInHierarchy)
            {
                healthPack.SetActive(true);
                i = 100;
            }
        }
    }
}
