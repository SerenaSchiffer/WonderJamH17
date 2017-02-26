using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {
    public GameObject[] players;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        players = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(players.Length);
        if(players.Length == 1)
        {
            EndScript.SetWinPlayer(players[0].GetComponentInParent<PlayableChar>().PlayerIdNumber);
            switch (players[0].transform.parent.name)
            {
                case "Rebel":
                    EndScript.SetClassID(0);
                    break;
                case "Anonymous":
                    EndScript.SetClassID(1);
                    break;
                case "BusinessMan":
                    EndScript.SetClassID(2);
                    break;
                case "Farmer":
                    EndScript.SetClassID(3);
                    break;
                default:
                    break;
            }
            Application.LoadLevel("End_Player");
        }
	}
}
