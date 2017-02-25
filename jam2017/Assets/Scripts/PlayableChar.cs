using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayableChar : MonoBehaviour
{
    // Character Attributes
    public int healthPoints;
    public float movSpeed;
    public float dashLength;

    protected Melee melWeapon;
    protected Guns rangWeapon;
    protected float fireRate;
    protected float nextShot;
    protected Animator myAnimator;
    public int damage;
    Transform viseur;
    public bool falling;

    protected int PlayerIdNumber;
    
    //enum Controls {Attack = "R2" ,Melee = "R1" ,SpecialAttack = "L1" };

    // Useful Functions
    public virtual void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    protected virtual void SpecialAttack(){ }
    protected virtual void RangeAttack() { }
    protected virtual void MeleeAttack() { }
    protected virtual void Dash() { }
    public void Update()
    {
        viseur = transform.GetChild(0);
        float xRight = Input.GetAxis("RightAxisXPlayer"+PlayerIdNumber);
        float yRight = Input.GetAxis("RightAxisYPlayer"+PlayerIdNumber) *-1;
        if (xRight != 0 || yRight != 0)
        {
            viseur.position = (new Vector2(xRight, yRight)).normalized;
            viseur.localPosition = Vector2.ClampMagnitude(viseur.position, 2);
        }
        
        if (Input.GetButtonDown("R1Player"+PlayerIdNumber))
        {
            myAnimator.SetTrigger("meleeAttack");
            MeleeAttack();
        }
        
        else myAnimator.SetBool("isShooting", false);

        float xLeft = Input.GetAxis("LeftAxisXPlayer" + PlayerIdNumber);
        float yLeft = Input.GetAxis("LeftAxisYPlayer" + PlayerIdNumber) * -1;
        Vector2 velocity = new Vector2(xLeft, yLeft);

        if (xLeft <0)
        {
            //this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            this.GetComponent<SpriteRenderer>().flipX = false;
            myAnimator.SetBool("isWalking", true);
        }
        else if(xLeft > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            myAnimator.SetBool("isWalking", true);
            //this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
        else  myAnimator.SetBool("isWalking", false);

        if (falling)
        {
            if (xLeft == 0 && yLeft == 0)
            {

            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = (velocity * movSpeed) / 3;
            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = velocity * movSpeed;
        }

    }

    protected virtual void UseSpecial()
    {
        // Effects of the special attack
    }

}
