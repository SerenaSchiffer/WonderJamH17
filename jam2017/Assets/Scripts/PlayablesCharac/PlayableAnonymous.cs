using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableAnonymous : PlayableChar {

    Transform viseur;
    AudioSource[] audioSources;
    public static int ID;
    // Use this for initialization
    public override void Awake()
    {
        melWeapon = new Katana();
        rangWeapon = new Uzi();
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
        GameObject.Find("EventSystem").GetComponent<Hack>().TurnOnHacking();
        audioSources[0].Play();
    }

    protected override void RangeAttack()
    {
        if (nextShot == 0)
        {
            nextShot = fireRate;
            Vector2 direction = viseur.position - transform.position;
            direction.Normalize();
            //Debug.Log(direction.x + " " + direction.y);
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/UziBullet"));
            audioSources[1].Play();
            bullet.transform.localScale /= 2;

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

            //bullet.transform.position = bulletSpawn.position;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bullet.GetComponent<Bullet>().damage = this.damage;
            bullet.GetComponent<Bullet>().Creator = this;
            bullet.GetComponent<SpriteRenderer>().color = ColorSystem.mainColors[PlayerIdNumber];
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
        GameObject hitBox = (GameObject)Instantiate(Resources.Load("Prefabs/SlashKatana"), new Vector2(transform.position.x + direction * 0.3f, transform.position.y - 0.25f), Quaternion.identity);
        audioSources[2].Play();
        hitBox.GetComponent<Bullet>().damage = meleeDamage;
        hitBox.GetComponent<Bullet>().timeToLive = 1f;
        hitBox.GetComponent<Bullet>().Creator = this;
    }
}
