﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableSuit : PlayableChar {
    Transform viseur;
    // Use this for initialization
    public override void Start()
    {
        melWeapon = new SuitCase();
        rangWeapon = new Pistol();
        viseur = transform.GetChild(0);
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }

    protected override void RangeAttack()
    {
        Vector2 direction = viseur.position - transform.position;
        direction.Normalize();
        Debug.Log(direction.x + " " + direction.y);
        GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/Bullet"));
        bullet.transform.position = transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10;
    }
}
