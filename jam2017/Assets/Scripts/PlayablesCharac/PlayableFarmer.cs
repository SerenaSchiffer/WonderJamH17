using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableFarmer : PlayableChar {

    // Use this for initialization
    public override void Start()
    {
        melWeapon = new PitchFork();
        rangWeapon = new Shotgun();
        Debug.Log("Yolo");
    }

    protected override void UseSpecial()
    {
        // Effects of the special attack
    }

    public void RangeWeapon()
    {

    }
}
