using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum SelectedAttack
{
    Soldier = 0,
    Robot = 1,
    Juggernaut = 2,
    Sniper = 3,
    Missile = 4
}

public enum SelectedSpawnPosition
{
    Left,
    Right,
    Bottom
}

public class Pewdiepie_UI : MonoBehaviour {

    public GameObject[] unit_icons;
    public Text myMoney;
    
    private int money;
    private bool raiseMoney;
    private SelectedAttack selectedAttack;

	// Use this for initialization
	void Start () {
        selectedAttack = SelectedAttack.Soldier;
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
            selectedAttack = SelectedAttack.Soldier;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedAttack = SelectedAttack.Robot;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedAttack = SelectedAttack.Juggernaut;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedAttack = SelectedAttack.Sniper;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedAttack = SelectedAttack.Soldier;
        }
        foreach (GameObject g in unit_icons)
            g.GetComponent<Image>().color = Color.white;
        unit_icons[(int)selectedAttack].GetComponent<Image>().color = Color.yellow;
        
        myMoney.text = money + " $";


        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 position = GameObject.Find("LeftSpawnPosition").transform.position;
            SpawnEnemy(position, SelectedSpawnPosition.Left);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 position = GameObject.Find("RightSpawnPosition").transform.position;
            SpawnEnemy(position, SelectedSpawnPosition.Right);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2 position = GameObject.Find("BottomSpawnPosition").transform.position;
            SpawnEnemy(position, SelectedSpawnPosition.Bottom);
        }
    }

    private void SpawnEnemy(Vector2 spawnPosition, SelectedSpawnPosition selectedSpawnPosition)
    {
        switch (selectedAttack)
        {
            case SelectedAttack.Soldier:
                GameObject soldiers = (GameObject)Instantiate(Resources.Load("Prefabs/Soldiers"));
                soldiers.transform.position = spawnPosition;
                soldiers.GetComponent<MovableEnemy>().type = TypeMoveableEnemy.Soldier;
                SetFollowSoldierPosition(soldiers, spawnPosition, selectedSpawnPosition);
                break;

            case SelectedAttack.Robot:
                GameObject robots = (GameObject)Instantiate(Resources.Load("Prefabs/Robot"));
                robots.transform.position = spawnPosition;
                robots.GetComponent<MovableEnemy>().type = TypeMoveableEnemy.Robot;
                break;

            case SelectedAttack.Juggernaut:
                Debug.Log("Spawn juggernaut");
                break;

            case SelectedAttack.Sniper:
                Debug.Log("Spawn sniper");
                break;

            case SelectedAttack.Missile:
                Debug.Log("Spawn missile");
                break;
        }
    }

    private void SetFollowSoldierPosition(GameObject soldiers, Vector2 spawnPosition, SelectedSpawnPosition selectedSpawnPosition)
    {
        Transform followSoldier1 = soldiers.transform.GetChild(1);
        Transform followSoldier2 = soldiers.transform.GetChild(2);

        switch (selectedSpawnPosition)
        {
            case SelectedSpawnPosition.Left:
            case SelectedSpawnPosition.Right:
                followSoldier1.position = spawnPosition + new Vector2(0, 0.75f);
                followSoldier2.position = spawnPosition + new Vector2(0, -0.75f);
                break;

            case SelectedSpawnPosition.Bottom:
                followSoldier1.position = spawnPosition + new Vector2(0.5f, 0);
                followSoldier2.position = spawnPosition + new Vector2(-0.5f, 0);
                break;
        }
    }
}
