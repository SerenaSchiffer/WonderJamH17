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

    public int PlayerIdNumber;
    
    //enum Controls {Attack = "R2" ,Melee = "R1" ,SpecialAttack = "L1" };

    // Useful Functions
    public virtual void Start(){ }
    protected virtual void SpecialAttack(){ }
    protected virtual void RangeAttack() { }
    protected virtual void MeleeAttack() { }
    protected virtual void Dash() { }
    public void Update()
    {
        float xRight = Input.GetAxis("RightAxisXPlayer"+PlayerIdNumber);
        float yRight = Input.GetAxis("RightAxisYPlayer"+PlayerIdNumber) *-1;
        Transform viseur = transform.GetChild(0);
        viseur.position = new Vector2(xRight*Mathf.PI, yRight* Mathf.PI);
        viseur.localPosition = Vector2.ClampMagnitude(viseur.position,2);

        //Todelete
        if (Input.GetButton("R1Player"+PlayerIdNumber))
        {
            RangeAttack();
        }

        float xLeft = Input.GetAxis("LeftAxisXPlayer" + PlayerIdNumber);
        float yLeft = Input.GetAxis("LeftAxisYPlayer" + PlayerIdNumber) * -1;
        Vector2 velocity = new Vector2(xLeft, yLeft);

        this.GetComponent<Rigidbody2D>().velocity= velocity*movSpeed;

    }

    protected virtual void UseSpecial()
    {
        // Effects of the special attack
    }
}
