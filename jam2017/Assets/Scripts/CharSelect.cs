using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour {

    int[] playerSelected;

    string[] charTexts = { "The Businessman", "The Rebel", "Anonymous", "The Farmer" };

    public Image[] images;
    public Text[] texts;

	// Use this for initialization
	void Start () {
        playerSelected = new int[4];
        for(int i = 0; i < 4; i++)
            playerSelected[i] = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (playerSelected[0] == 0)
                playerSelected[0] = 4;
            playerSelected[0] -= 1;
            playerSelected[0] %= 4;
            texts[0].text = charTexts[playerSelected[0]];
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerSelected[0] += 1;
            playerSelected[0] %= 4;
            texts[0].text = charTexts[playerSelected[0]];
        }

    }
}
