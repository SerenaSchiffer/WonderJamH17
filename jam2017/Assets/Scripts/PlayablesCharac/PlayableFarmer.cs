using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableFarmer : PlayableChar {

    Transform viseur;
    public int NbrBullet;
    public float spread;
    public static int ID;
    // Use this for initialization
    public override void Start()
    {
        melWeapon = new PitchFork();
        rangWeapon = new Shotgun();
        Debug.Log("Yolo");
        nextShot = 0;
        viseur = transform.GetChild(0);
        PlayerIdNumber = ID;
        base.Start();
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }

    protected override void RangeAttack()
    {
        if (nextShot == 0)
        {
            nextShot = 1.5f;
            Vector2 direction = viseur.position - transform.position;
            direction.Normalize();
            Debug.Log(direction.x + " " + direction.y);
            for (int i = 0; i < NbrBullet; i++)
            {
                float random = Random.Range(-spread, spread);
                direction = Quaternion.AngleAxis(random, Vector3.forward) * direction;
                GameObject bullet = (GameObject)Instantiate(Resources.Load("Prefabs/ShotgunBullet"));
                bullet.transform.position = transform.position;
                float randSpeed = Random.Range(8f, 11f);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * randSpeed;
                bullet.GetComponent<Bullet>().damage = this.damage;
            }
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
}
