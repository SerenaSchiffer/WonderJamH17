using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chickenscript : MonoBehaviour {
    public float speed;
    public float timeToLive;
    public int damage;
    public Vector2 direction;

    private int sprintFrames;
    private int attackDelay;
    private int currentDelay;
    private float currentSpeed;
    private Rigidbody2D myrb2d;

	// Use this for initialization
	void Start () {
        sprintFrames = 30;
        myrb2d = GetComponent<Rigidbody2D>();
        if (direction.x > 0)
            GetComponent<SpriteRenderer>().flipX = true;
    }
	
	// Update is called once per frame
	void Update () {
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
            Destroy(gameObject);

        sprintFrames--;
        if (sprintFrames >= 0)
            currentSpeed = speed * 3f;
        else currentSpeed = speed;

        myrb2d.velocity = direction * currentSpeed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<EnemyScript>().Damage(damage);
    }
}
