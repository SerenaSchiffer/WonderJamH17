using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableAnonymous : PlayableChar {

    Transform viseur;

    // Use this for initialization
    public override void Start()
    {
        melWeapon = new Katana();
        rangWeapon = new Uzi();
        viseur = transform.GetChild(0);
        nextShot = 0;
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }

    protected override void RangeAttack()
    {
        if (nextShot == 0)
        {
            nextShot = 0.08f;
            Vector2 direction = viseur.position - transform.position;
            direction.Normalize();
            Debug.Log(direction.x + " " + direction.y);
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/UziBullet"));
            bullet.transform.localScale /= 2;
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 12;
            bullet.GetComponent<Bullet>().damage = this.damage;
        }
        if(nextShot > 0)
        {
            nextShot -= Time.deltaTime;
        }
        if(nextShot < 0)
        {
            nextShot = 0;
        }
    }

}
