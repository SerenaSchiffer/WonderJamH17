using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour {

    int[] playerSelected;

    string[] charTexts = { "The  Businessman", "The  Rebel", "Anonymous", "The  Farmer" };

    public Image[] images;
    public Text[] texts;
    bool axis1, axis2, axis3, axis4;
    bool selected1, selected2, selected3, selected4;

	// Use this for initialization
	void Start () {
        playerSelected = new int[4];
        for(int i = 0; i < 4; i++)
            playerSelected[i] = i;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //select1
        if (Input.GetAxisRaw("LeftAxisXPlayer1") != 0)
        {
            if (!axis1)
            {
                // Call your event function here.
                if (Input.GetAxisRaw("LeftAxisXPlayer1") < 0)
                {
                    if (playerSelected[0] == 0)
                        playerSelected[0] = 4;
                    playerSelected[0] -= 1;
                    playerSelected[0] %= 4;
                }
                else
                {
                    playerSelected[0] += 1;
                    playerSelected[0] %= 4;
                }
                axis1 = true;
            }
        }
        else
        {
            axis1 = false;
        }


        //////////////////Player2

        if (Input.GetAxisRaw("LeftAxisXPlayer2") != 0)
        {
            if (!axis2)
            {
                // Call your event function here.
                if (Input.GetAxisRaw("LeftAxisXPlayer2") < 0)
                {
                    if (playerSelected[1] == 0)
                        playerSelected[1] = 4;
                    playerSelected[1] -= 1;
                    playerSelected[1] %= 4;
                }
                else
                {
                    playerSelected[1] += 1;
                    playerSelected[1] %= 4;
                }
                axis2 = true;
            }
        }
        else
        {
            axis2 = false;
        }

        ///////////////////Player3

        if (Input.GetAxisRaw("LeftAxisXPlayer3") != 0)
        {
            if (!axis3)
            {
                // Call your event function here.
                if (Input.GetAxisRaw("LeftAxisXPlayer3") < 0)
                {
                    if (playerSelected[2] == 0)
                        playerSelected[2] = 4;
                    playerSelected[2] -= 1;
                    playerSelected[2] %= 4;
                }
                else
                {
                    playerSelected[2] += 1;
                    playerSelected[2] %= 4;
                }
                axis3 = true;
            }
        }
        else
        {
            axis3 = false;
        }


        ///////////////Player4

        if (Input.GetAxisRaw("LeftAxisXPlayer4") != 0)
        {
            if (!axis4)
            {
                // Call your event function here.
                if (Input.GetAxisRaw("LeftAxisXPlayer4") < 0)
                {
                    if (playerSelected[3] == 0)
                        playerSelected[3] = 4;
                    playerSelected[3] -= 1;
                    playerSelected[3] %= 4;
                }
                else
                {
                    playerSelected[3] += 1;
                    playerSelected[3] %= 4;
                }
                axis4 = true;
            }
        }
        else
        {
            axis4 = false;
        }


        for (int i = 0; i < 4; i++)
        {
            texts[i].text = charTexts[playerSelected[i]];
            images[i].sprite = Resources.Load<Sprite>("Selection/select" + playerSelected[i]);
        }
    }
}
