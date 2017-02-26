using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage = 0;
    public float timeToLive;
    public PlayableChar Creator;

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
            Debug.Log("Je pogne l'ennemi");
            Destroy(this.gameObject);
            int points = other.GetComponentInParent<EnemyScript>().Damage(damage);
            if(points > 0)
            {
                Creator.UpdatePoint(points);
                Destroy(other.transform.parent.gameObject);
            }
        }
        if(other.tag == "Player" && tag!= "Player" && tag!="PlayerBullet")
        {
            other.GetComponentInParent<PlayableChar>().SetHp(-damage);
            Destroy(this.gameObject);
        }
    }
}
