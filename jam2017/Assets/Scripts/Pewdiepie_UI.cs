﻿using System.Collections;
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
    Left = 1,
    Right = 3,
    Bottom = 2
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
            selectedAttack = SelectedAttack.Missile;
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

    private void SpawnEnemy(Vector2 spawnPosition, SelectedSpawnPosition ssp)
    {
        GameObject spawnedAttack;

        switch (selectedAttack)
        {
            case SelectedAttack.Soldier:
                spawnedAttack = (GameObject)Instantiate(Resources.Load("Prefabs/Soldier"));
                spawnedAttack.transform.position = spawnPosition;
                spawnedAttack.GetComponent<MovableEnemy>().type = TypeMoveableEnemy.Soldier;
                break;

            case SelectedAttack.Robot:
                spawnedAttack = (GameObject)Instantiate(Resources.Load("Prefabs/Robot"));
                spawnedAttack.transform.position = spawnPosition;
                spawnedAttack.GetComponent<MovableEnemy>().type = TypeMoveableEnemy.Robot;
                break;

            case SelectedAttack.Juggernaut:
                spawnedAttack = (GameObject)Instantiate(Resources.Load("Prefabs/Juggernaut"));
                spawnedAttack.transform.position = spawnPosition;
                spawnedAttack.GetComponent<MovableEnemy>().SetSelectedSpawnPosition(ssp);
                break;

            case SelectedAttack.Sniper:
                spawnedAttack = (GameObject)Instantiate(Resources.Load("Prefabs/Sniper"));
                spawnedAttack.transform.position = spawnPosition;
                spawnedAttack.GetComponent<MovableEnemy>().SetSelectedSpawnPosition(ssp);
                break;

            case SelectedAttack.Missile:
                GetComponent<Missile>().SelectLocation((int)ssp);
                GetComponent<Missile>().missileIsTriggered = true;
                break;
        }
    }
}
