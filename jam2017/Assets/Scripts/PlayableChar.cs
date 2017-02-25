using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayableChar : MonoBehaviour
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

public class PlayableSuit : PlayableChar
{
    public override void Start()
    {
        melWeapon = new SuitCase();
        rangWeapon = new Pistol();
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }
}

public class PlayableRebel : PlayableChar
{
    public override void Start()
    {
        melWeapon = new Lightsaber();
        rangWeapon = new LaserGun();
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }
}

public class Playable4Chan : PlayableChar
{
    public override void Start()
    {
        melWeapon = new Katana();
        rangWeapon = new Uzi();
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }
}

public class PlayableRedneck : PlayableChar
{
    public override void Start()
    {
        melWeapon = new PitchFork();
        rangWeapon = new Shotgun();
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }
}