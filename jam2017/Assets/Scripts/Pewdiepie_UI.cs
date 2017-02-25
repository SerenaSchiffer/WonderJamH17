using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pewdiepie_UI : MonoBehaviour {

    public GameObject[] unit_icons;
    public Text myMoney;

    private int selected;
    private int money;
    private bool raiseMoney;


	// Use this for initialization
	void Start () {
        selected = 0;
        money = 100;
        raiseMoney = true;
        StartCoroutine(AddMoney());
    }
	
    IEnumerator AddMoney()
    {
        int moneyFactor = 10;

        while (raiseMoney)
        {
            yield return new WaitForSeconds(1f);
            money += moneyFactor;
            moneyFactor += 10;
        }
        yield return null;
    }

	// Update is called once per frame
	void Update () {
        // Je m'excuse
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selected = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selected = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selected = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selected = 4;
        }
        foreach (GameObject g in unit_icons)
            g.GetComponent<Image>().color = Color.white;
        unit_icons[selected].GetComponent<Image>().color = Color.yellow;
        
        myMoney.text = money + " $";

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // try to spawn using KeyCode.Direction, int selected
        }
    }
}
