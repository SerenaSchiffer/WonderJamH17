using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableAnonymous : PlayableChar {

    // Use this for initialization
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
