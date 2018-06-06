using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public int hp, damage, points;
    private GameObject myHealthBar;
    private int maxHp;
    private bool alreadyGavePoints;

    // Use this for initialization
    void Start ()
    {
        maxHp = hp;
        myHealthBar = Instantiate(Resources.Load("Prefabs/EnemyHealthBar")) as GameObject;
        myHealthBar.transform.SetParent(GameObject.Find("MainGame_UI").transform, false);
    }
	
	// Update is called once per frame
	void Update () {
        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y - 0.6f));
    }

    public int Damage(int damage)
    {
        hp -= damage;
        myHealthBar.GetComponent<Slider>().value = (float)hp / (float)maxHp;
        if (hp <= 0 && !alreadyGavePoints)
        {
            alreadyGavePoints = true;
            return points;
        }
        else return 0;
    }

    void OnDestroy()
    {
        Destroy(myHealthBar);
    }
}
