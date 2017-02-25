using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableSuit : PlayableChar {

    // Use this for initialization
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
