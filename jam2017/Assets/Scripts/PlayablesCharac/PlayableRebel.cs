using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableRebel : PlayableChar {

    Transform viseur;
    public static int ID;
    GameObject Xwing;

    // Use this for initialization
    public override void Start()
    {
        
        melWeapon = new Lightsaber();
        rangWeapon = new LaserGun();
        viseur = transform.GetChild(0);
        nextShot = 0;
        PlayerIdNumber = ID;
        base.Start();
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
        if (!Xwing)
        {
            Xwing = (GameObject)Instantiate(Resources.Load("Prefabs/XWingContainer"));
        }
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


            Vector2 bulletSpawn = transform.position;
            if (viseur.transform.position.x - gameObject.transform.position.x > 0)
            {
                bulletSpawn = new Vector2(bulletSpawn.x + 0.25f, bulletSpawn.y);
            }
            else if (viseur.transform.position.x - gameObject.transform.position.x < 0)
            {
                bulletSpawn = new Vector2(bulletSpawn.x - 0.25f, bulletSpawn.y);
            }
            
            bullet.transform.localPosition= bulletSpawn;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 10;
            bullet.GetComponent<Bullet>().damage = this.damage;
            bullet.GetComponent<Bullet>().Creator = this;
            bullet.GetComponent<SpriteRenderer>().color = ColorSystem.mainColors[PlayerIdNumber];
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
        int direction = -1;
        if (GetComponent<SpriteRenderer>().flipX)
            direction = 1;
        GameObject hitBox = (GameObject)Instantiate(Resources.Load("Prefabs/SlashLightsaber"), new Vector2(transform.position.x + direction * 0.3f, transform.position.y - 0.25f), Quaternion.identity);
        hitBox.GetComponent<Bullet>().damage = meleeDamage;
        hitBox.GetComponent<Bullet>().timeToLive = 1f;
    }
}
