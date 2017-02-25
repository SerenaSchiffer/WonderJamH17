using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableRebel : PlayableChar {

    Transform viseur;
    public static int ID;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        melWeapon = new Lightsaber();
        rangWeapon = new LaserGun();
        viseur = transform.GetChild(0);
        nextShot = 0;
        PlayerIdNumber = ID;
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
            bullet.GetComponent<Bullet>().damage = this.damage;
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

    public static void UpdateID(int id)
    {
        ID = id;
    }
    protected override void MeleeAttack()
    {
        meleeAttack = 60;
    }
}
