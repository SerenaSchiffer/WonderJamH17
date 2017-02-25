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

    // Useful Functions
    public virtual void Start(){ }
    protected virtual void SpecialAttack(){ }

    public void Update()
    {
        // Check for controls
    }

    protected virtual void UseSpecial()
    {
        // Effects of the special attack
    }
}
