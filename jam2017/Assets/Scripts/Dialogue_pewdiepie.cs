using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_pewdiepie : MonoBehaviour {

    public GameObject panel;
    public Text text;
    public Text money;
    public Text nuke;
    public GameObject pewdiepieUI;

    private string[] waveTexts = { "There  is  no  tolerance  for  rebels.        \nLay  down  your  weapons  and  your  family\nWill  be  spared.",
        "How  amusing.     \nDid  you  notice  you  can  collect  points ...     \nAim  for  a  high  score !",
        "That  really  is  weird.     \nYou  can  push  your  allies  around!     \nMaybe  that  could  help  you  gather  more  points ...",
        "I've  made  up my  mind.     \nIf  only  one  of  you  is  left  alive,  he  will\nbe  my  right  hand.  You  know  what  you  need  to  do.",
        "Still  not  done  ...  Hurry  up!     \nI'm  getting  tired  and  I  can  stop  this\nwhenever  I  want." };

    private int currentWave = 0;
    private int aliveFrames = 0;
    public float timeBetweenWaves;
    private float elapseTime;

	void Update ()
    {
        if (GameObject.Find("Dia_Pewds"))
        {
            Debug.Log(waveTexts[currentWave-1].Length);
            if (aliveFrames / 3 == waveTexts[currentWave-1].Length)
                StartCoroutine(CloseWindow());

            if (aliveFrames / 3 > waveTexts[currentWave-1].Length)
                return;

            text.text = waveTexts[currentWave - 1].Substring(0, aliveFrames / 3);
            aliveFrames++;
        }
        elapseTime += Time.deltaTime;

        if(elapseTime >= timeBetweenWaves)
        {
            elapseTime = 0;
            StartWave(currentWave);
            Debug.Log("wave:" + currentWave);
            currentWave++;
        }

	}

    void StartWave(int waveNumber)
    {
        if (currentWave < waveTexts.Length)
        {
            panel.SetActive(true);
            currentWave = waveNumber;
            aliveFrames = 0;
            
        }
        else
        {
            KillPlayers();
        }
        
    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }

    void KillPlayers()
    {
        nuke.gameObject.SetActive(true);
        pewdiepieUI.GetComponent<Pewdiepie_UI>().ActivateNuke();
        money.text = "Infinite $";
    }
}
