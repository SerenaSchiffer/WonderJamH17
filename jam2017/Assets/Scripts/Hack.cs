using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hack : MonoBehaviour {
    public static bool beingHacked;
    GameObject hackPanel;


    // Use this for initialization
    void Start () {
        hackPanel = GameObject.Find("Hack");
        if (hackPanel)
        {
            hackPanel.SetActive(false);
            beingHacked = false;
        }
    }
	
	public void TurnOnHacking()
    {
        beingHacked = true;
        hackPanel.SetActive(true);
        StartCoroutine(StopHack());
    }

    IEnumerator StopHack()
    {
        yield return new WaitForSeconds(5f);
        beingHacked = false;
        hackPanel.SetActive(false);
    }
}
