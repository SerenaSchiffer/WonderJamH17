using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour {

    int selected = 0;
    int lastJoystickUse;

    public Text[] textBoxes;
	
    void Start()
    {
        PlayableAnonymous.UpdateID(0);
        PlayableFarmer.UpdateID(0);
        PlayableRebel.UpdateID(0);
        PlayableSuit.UpdateID(0);
    }

	// Update is called once per frame
	void Update () {
        lastJoystickUse--;
        foreach(Text t in textBoxes)
            t.color = Color.white;
        textBoxes[selected].color = Color.yellow;



        if( (Input.GetAxisRaw("Horizontal") == 1f || Input.GetKey(KeyCode.RightArrow) ) && lastJoystickUse < 0)
        {
            selected += 1;
            selected %= 3;
            lastJoystickUse = 10;
        }

        if ((Input.GetAxisRaw("Horizontal") == -1f || Input.GetKey(KeyCode.LeftArrow)) && lastJoystickUse < 0)
        {
            if (selected == 0)
                selected = 2;
            else selected -= 1;
            lastJoystickUse = 10;
        }



        if (Input.GetButtonDown("SelectMenu") || Input.GetKeyDown(KeyCode.Space))
        {
            switch (selected)
            {
                case 0:
                    SceneManager.LoadScene("char_select");
                    break;
                case 1:
                    SceneManager.LoadScene("controls");
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
            
        }
	}
}
