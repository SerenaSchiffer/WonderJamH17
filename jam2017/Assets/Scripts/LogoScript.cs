using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(load_main_scene());
	}

    IEnumerator load_main_scene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Intro");
    }
	
}