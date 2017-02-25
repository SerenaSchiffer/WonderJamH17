﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableRebel : PlayableChar {

    Transform viseur;

    // Use this for initialization
    public override void Start()
    {        
        melWeapon = new Lightsaber();
        rangWeapon = new LaserGun();
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
            nextShot = 0.6f;
            Vector2 direction = viseur.position - transform.position;
            direction.Normalize();
            Debug.Log(direction.x + " " + direction.y);
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/Lazer"));
            float angle = Vector2.Angle(direction, new Vector2(1, 0));
            if(direction.y < 0)
            {
                angle = -angle;
            }
            bullet.transform.Rotate(0, 0, angle);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 10;
        }
        if (nextShot > 0)
        {
            nextShot -= Time.deltaTime;
        }
        if (nextShot < 0)
        {
            nextShot = 0;
        }
    }
}
