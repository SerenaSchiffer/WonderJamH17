using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Escape) || Input.GetButtonUp("SelectMenu"))
            SceneManager.LoadScene("Title");
	}
}
