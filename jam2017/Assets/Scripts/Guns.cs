using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns
{
    protected AudioClip sfx;
    protected GameObject bullet;

    public Guns()
    {

    }
}

public class Pistol : Guns
{
    public Pistol() : base() // Constructeur
    {

    }
}

public class LaserGun : Guns
{
    public LaserGun() : base() // Constructeur
    {

    }
}

public class Uzi : Guns
{
    public Uzi() : base() // Constructeur
    {

    }
}

public class Shotgun : Guns
{
    public Shotgun() : base() // Constructeur
    {

    }
}