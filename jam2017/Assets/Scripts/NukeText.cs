using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NukeText : MonoBehaviour {

    Text nuke;
    float fadeColor;
    bool ascend = true;

	// Use this for initialization
	void Start () {
        nuke = GetComponent<Text>();
        fadeColor = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (ascend)
        {
            fadeColor += 0.02f;
        }
        else
        {
            fadeColor -= 0.02f;
        }


        if (fadeColor >= 1)
        {
            ascend = true;
            fadeColor = 0;
        }
        if (fadeColor <= 0)
        {
            ascend = false;
            fadeColor = 1;
        }
        nuke.color = new Color(1, 0, 0, fadeColor);
    }
}
