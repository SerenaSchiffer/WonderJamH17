using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableSuit : PlayableChar {
    Transform viseur;
    AudioSource[] audioSources;
    public static int ID;

    GameObject denied;
    // Use this for initialization
    public override void Awake()
    {
        melWeapon = new SuitCase();
        rangWeapon = new Pistol();
        viseur = transform.GetChild(0);
        nextShot = 0;
        PlayerIdNumber = ID;
        audioSources = GetComponents<AudioSource>();
        base.Awake();
    }

    protected override void UseSpecial()
    {
        base.UseSpecial();
        // Effects of the special attack
        if (!denied)
        {
            denied = (GameObject)Instantiate(Resources.Load("Prefabs/DeniedAttack"));
            denied.transform.position = GameObject.Find("BusinessMan").transform.GetChild(0).transform.position;
            int points = denied.GetComponent<StampDownUp>().GetPointsGot();
            UpdatePoint(points);
            
            audioSources[0].PlayDelayed(1);
        }
    }

    protected override void RangeAttack()
    {
        if (nextShot == 0)
        {
            nextShot = fireRate;
            Vector2 direction = viseur.position - transform.position;
            direction.Normalize();
            //Debug.Log(direction.x + " " + direction.y);
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/Bullet"));
            audioSources[1].Play();

            Vector2 bulletSpawn = transform.position;
            if (viseur.transform.position.x - gameObject.transform.position.x > 0)
            {
                bulletSpawn = new Vector2(bulletSpawn.x + 0.25f, bulletSpawn.y);
            }
            else if (viseur.transform.position.x - gameObject.transform.position.x < 0)
            {
                bulletSpawn = new Vector2(bulletSpawn.x - 0.25f, bulletSpawn.y);
            }

            bullet.transform.localPosition = bulletSpawn;

            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
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
        GameObject hitBox = (GameObject)Instantiate(Resources.Load("Prefabs/SlashSuitcase"), new Vector2(transform.position.x + direction * 0.3f, transform.position.y - 0.25f), Quaternion.identity);
        audioSources[2].Play();
        hitBox.GetComponent<Bullet>().damage = meleeDamage;
        hitBox.GetComponent<Bullet>().timeToLive = 1f;
        hitBox.GetComponent<Bullet>().Creator = this;
    }
}
