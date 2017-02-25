using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hack : MonoBehaviour {

    GameObject hackPanel;

	// Use this for initialization
	void Start () {
        hackPanel = GameObject.Find("Hack");
        hackPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
