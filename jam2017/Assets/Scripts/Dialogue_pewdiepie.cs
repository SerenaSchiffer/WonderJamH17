using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_pewdiepie : MonoBehaviour {

    public GameObject panel;
    public Text text;

    public string[] waveTexts = { "There  is  no  tolerance  for  rebels\nLay  down  your  weapons  and  your  family\nWill  be  spared" };

    private int currentWave;
    private int aliveFrames = 0;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartWave(0);
    }

	void Update ()
    {
        if (GameObject.Find("Dia_Pewds"))
        {
            if (aliveFrames / 3 == waveTexts[currentWave].Length)
                StartCoroutine(CloseWindow());

            if (aliveFrames / 3 > waveTexts[currentWave].Length)
                return;

            text.text = waveTexts[0].Substring(0, aliveFrames / 3);
            aliveFrames++;
        }
	}

    void StartWave(int waveNumber)
    {
        panel.SetActive(true);
        currentWave = waveNumber;
        aliveFrames = 0;
    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }
}
