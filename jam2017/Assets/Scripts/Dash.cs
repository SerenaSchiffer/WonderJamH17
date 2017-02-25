using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {


    private int playerID;
    public float dashRate;

    public float timeToDieDash;
    private float actualTime;
    private float fadeValue;
    GameObject dashSprite;
	// Use this for initialization
	void Start () {
        playerID = gameObject.GetComponent<PlayableChar>().PlayerIdNumber;
        actualTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(dashSprite)
        {
            actualTime += Time.deltaTime;
            Color actualValue= dashSprite.GetComponent<SpriteRenderer>().color;
            Color theNewFade = new Color(actualValue.r,actualValue.g,actualValue.b,actualValue.a - fadeValue);
            if(actualTime>=timeToDieDash)
            {
                Destroy(dashSprite);
            }
        }
        else
        {
            actualTime = 0;
        }


	    if(Input.GetButtonDown("DashPlayer"+ playerID))
        {
            Vector2 pos1 = transform.position;
            Vector2 joystickOrientation = new Vector2(Input.GetAxis("LeftAxisXPlayer" + playerID), Input.GetAxis("LeftAxisYPlayer" + playerID)*-1);

            float angle = Vector2.Angle(joystickOrientation, new Vector2(1, 0));
            if(joystickOrientation.y <0)
            {
                angle *= -1;
            }


            
            joystickOrientation = joystickOrientation.normalized;
            transform.position += new Vector3(joystickOrientation.x * dashRate*Time.deltaTime, joystickOrientation.y * dashRate * Time.deltaTime, 0.0f);
            Vector2 pos2 = transform.position;
            Vector2 posCentre = (pos1 + pos2) / 2;
            dashSprite = (GameObject)Instantiate(Resources.Load("Prefabs/dash"));
            dashSprite.transform.position = posCentre;
            dashSprite.transform.Rotate(0, 0, angle);

            fadeValue = 100f / (timeToDieDash / Time.deltaTime);
        }
	}
}
