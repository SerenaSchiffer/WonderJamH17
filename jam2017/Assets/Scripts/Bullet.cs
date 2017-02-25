using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float damage = 0;
    public float timeToLive;

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    void Update()
    {
        if(timeToLive > 0)
        {
            timeToLive -= Time.deltaTime;
        }
        if(timeToLive <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
