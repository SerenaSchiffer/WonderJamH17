using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage = 0;
    public float timeToLive;

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            other.GetComponentInParent<EnemyScript>().Damage(damage);
        }
        if(other.tag == "Player" && tag != "Player" )
        {
            other.GetComponent<PlayableChar>().SetHp(-damage);
            Destroy(this.gameObject);
        }
    }
}
