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
        GameObject shootEffect = null;

        if(other.tag == "Enemy")
        {
            shootEffect = (GameObject)Instantiate(Resources.Load("Prefabs/ShootEffect"));
            shootEffect.transform.position = other.transform.position;

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
            shootEffect = (GameObject)Instantiate(Resources.Load("Prefabs/ShootEffect"));
            shootEffect.transform.position = other.transform.position;

            other.GetComponentInParent<PlayableChar>().SetHp(-damage);
            Destroy(this.gameObject);
        }

        Destroy(shootEffect, 0.25f);
    }
}
