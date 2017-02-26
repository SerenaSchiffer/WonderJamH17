using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour {

    public static int WinPlayer = 0;
    public static int ClassID = 0;
    public Text textBox;

    string dialogue = "You  chose  wisely";

    int aliveTime;

	// Use this for initialization
	void Start () {
        GameObject.Find("Pewd").transform.GetChild(ClassID).gameObject.SetActive(true);
        dialogue = "Player  " + WinPlayer + "                \n" + dialogue;
        aliveTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (aliveTime / 3 > dialogue.Length)
            return;

        textBox.text = dialogue.Substring(0, aliveTime / 3);
        aliveTime++;
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
