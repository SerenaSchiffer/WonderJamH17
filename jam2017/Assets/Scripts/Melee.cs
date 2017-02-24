using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Melee
{
    protected AudioClip sfx;
    protected GameObject hitbox;

    public Melee()
    {

    }
}

public class SuitCase : Melee {
    
    public SuitCase() : base() // Constructeur
    {

    }
}

public class Lightsaber : Melee
{
    public Lightsaber() : base() // Constructeur
    {

    }
}

public class Katana : Melee
{
    public Katana() : base() // Constructeur
    {

    }
}

public class PitchFork : Melee
{
    public PitchFork() : base() // Constructeur
    {

    }
}