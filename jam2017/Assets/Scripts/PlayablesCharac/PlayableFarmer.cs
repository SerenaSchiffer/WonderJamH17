using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableFarmer : PlayableChar {

    Transform viseur;
    public int NbrBullet;
    public float spread;
    public static int ID;

    private GameObject chicken;
    // Use this for initialization
    public override void Awake()
    {
        melWeapon = new PitchFork();
        rangWeapon = new Shotgun();
        nextShot = 0;
        viseur = transform.GetChild(0);
        PlayerIdNumber = ID;
        base.Awake();
    }

    protected override void UseSpecial()
    {
        base.UseSpecial();
        // Effects of the special attack
        Vector2 direction = viseur.position - transform.position;
        if (!chicken)
        {
            chicken = (GameObject)Instantiate(Resources.Load("Prefabs/Chicken"));
            chicken.transform.position = transform.position;
            chicken.GetComponent<Chickenscript>().damage = 100;
            chicken.GetComponent<Chickenscript>().direction = direction.normalized;
        }
    }

    public void FixedUpdate()
    {
        if (nextShot > 0)
        {
            Debug.Log("nextShot > 0");
            nextShot -= Time.deltaTime;
        }
        if (nextShot < 0)
        {
            Debug.Log("nextShot < 0");
            nextShot = 0;
        }
    }

    protected override void RangeAttack()
    {
        if (nextShot == 0)
        {

            nextShot = fireRate;
            Vector2 direction = viseur.position - transform.position;
            direction.Normalize();
            Debug.Log("nextShot = 0");
            for (int i = 0; i < NbrBullet; i++)
            {
                float random = Random.Range(-spread, spread);
                direction = Quaternion.AngleAxis(random, Vector3.forward) * direction;
                GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/ShotgunBullet"));
                
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


                float randSpeed = Random.Range(8f, 11f);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * randSpeed;
                bullet.GetComponent<Bullet>().damage = this.damage;
                bullet.GetComponent<Bullet>().Creator = this;
                bullet.GetComponent<SpriteRenderer>().color = ColorSystem.mainColors[PlayerIdNumber];
            }
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
        GameObject hitBox = (GameObject)Instantiate(Resources.Load("Prefabs/SlashPitchfork"), new Vector2(transform.position.x + direction * 0.3f, transform.position.y - 0.25f), Quaternion.identity);
        hitBox.GetComponent<Bullet>().damage = meleeDamage;
        hitBox.GetComponent<Bullet>().timeToLive = 1f;
        hitBox.GetComponent<Bullet>().Creator = this;
    }
}
