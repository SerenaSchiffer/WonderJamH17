using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    private float actualTime = 0;
    public float timeToStrike;
    public float damage;
    public bool missileIsTriggered;
    private float valuePerFrame = 0;
    GameObject MissileSight;
    Transform nukeTransform;
    enum location { left=1,center=2,right=3}

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(missileIsTriggered)
        {
            MissileTriggered(1);
            valuePerFrame = (float)(((float)MissileSight.transform.GetChild(0).transform.position.y - 0.871) / ((float)timeToStrike / (float)Time.deltaTime));
            missileIsTriggered = false;
        }

        if (MissileSight)
        {
            if (missileIsTriggered)
            {
                MissileTriggered(1);
                missileIsTriggered = false;
            }

            if (actualTime <= timeToStrike)
            {
                Debug.Log(nukeTransform.position.y);
                actualTime += Time.deltaTime;
                nukeTransform.position = new Vector3(nukeTransform.position.x, nukeTransform.position.y-valuePerFrame, nukeTransform.position.z);
                if(MissileSight.transform.GetChild(0).transform.position.y<=0.571)
                {
                    actualTime = timeToStrike + 1;
                }
            }
            else
            {
                MissileExplode();
                
            }
        }


	}

    public void MissileTriggered(int location)
    {
        GameObject missileLocation = (GameObject)Instantiate(Resources.Load("Prefabs/MissileLocation" + location));
        float minX = missileLocation.transform.position.x - (missileLocation.transform.localScale.x / 2);
        float maxX = missileLocation.transform.position.x + (missileLocation.transform.localScale.x / 2);
        float randomX = Random.Range(minX,maxX );

        float minY = missileLocation.transform.position.y - (missileLocation.transform.localScale.y / 2); ;
        float maxY = missileLocation.transform.position.y + (missileLocation.transform.localScale.y / 2); ;
        float randomY = Random.Range(minY,maxY);

        Destroy(missileLocation);

        MissileSight = (GameObject)Instantiate(Resources.Load("Prefabs/MissileIncoming"));
        nukeTransform = MissileSight.transform.GetChild(0).transform;
        MissileSight.transform.position = new Vector2(randomX, randomY);
    }

    public void MissileExplode()
    {
        GameObject explosion = (GameObject)Instantiate(Resources.Load("Prefabs/Explosion"));
        explosion.transform.position = MissileSight.transform.position;
        GameObject hole = (GameObject)Instantiate(Resources.Load("Prefabs/Hole"));
        hole.transform.position = MissileSight.transform.position;
        Destroy(MissileSight);

        actualTime = 0;
    }
}
