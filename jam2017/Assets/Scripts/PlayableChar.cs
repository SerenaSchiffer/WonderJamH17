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

    int PlayerIdNumber;
    //enum Controls {Attack = "R2" ,Melee = "R1" ,SpecialAttack = "L1" };

    // Useful Functions
    public virtual void Start(){ }
    protected virtual void SpecialAttack(){ }

    public void Update()
    {
        float x = Input.GetAxisRaw("RightAxisXPlayer1");
        float y = Input.GetAxisRaw("RightAxisYPlayer1");
        Transform viseur = transform.GetChild(0);
        viseur.position = new Vector2(x, y) * 2;

        Debug.Log(x + " " + y);
        // Check for controls
        /*if (Input.GetButtonDown("LeftAxisXPlayer"+PlayerIdNumber))
        {
            
        }*/
    }

    protected virtual void UseSpecial()
    {
        // Effects of the special attack
    }
}
