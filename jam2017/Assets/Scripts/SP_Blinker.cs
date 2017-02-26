using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SP_Blinker : MonoBehaviour {

    public Image[] fillAreas;
    public static bool[] blinking = { false, false, false, false };


	public static void StartBlinking(int i)
    {
        Debug.Log("BLINK 182 " + i);
        blinking[i] = true;
    }

    public static void EndBlinking(int i)
    {
        blinking[i] = false;
    }

    float currentFade;
    bool fadeGoUp; 

    // Jaune = 1 1 0
    // Bleu =  0 1 1

    void Start()
    {
        currentFade = 0f;
        fadeGoUp = true;
    }

    void Update()
    {
        if (fadeGoUp)
            currentFade += 0.03f;
        else currentFade -= 0.03f;

        if (currentFade > 1f)
            fadeGoUp = false;
        if (currentFade < 0f)
            fadeGoUp = true;

        for(int i = 0; i < 4; i++)
        {
            if (blinking[i])
                fillAreas[i].color = new Color(currentFade, 1, 1f - currentFade);
            else
                fillAreas[i].color = new Color(0, 1, 1);
        }
    }
}
