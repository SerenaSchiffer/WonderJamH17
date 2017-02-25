using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableRebel : PlayableChar {

    // Use this for initialization
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
