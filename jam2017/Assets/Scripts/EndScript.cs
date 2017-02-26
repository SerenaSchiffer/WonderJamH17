using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

    public static int WinPlayer = 0;
    public static int ClassID = 0;

	// Use this for initialization
	void Start () {
		if(WinPlayer == 0)
        {

        }
        else
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetWinPlayer(int id)
    {
        WinPlayer = id;
    }

    public static void SetClassID(int id)
    {
        ClassID = id;
    }
}
