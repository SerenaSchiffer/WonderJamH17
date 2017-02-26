using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    public float timeToDie; //Preferable settin = 0.6
    private float actualTime;
    private float fadeValue;
    public bool destroyAfter;
    public bool isCharacter = false;
    GameObject ObjectToFade;
    public GameObject OptionnalObjectToDestroy;


    // Use this for initialization
    void Start () {
        ObjectToFade = gameObject;
        fadeValue = 1f / (timeToDie / Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
            actualTime += Time.deltaTime;
            //Debug.Log(actualTime);
            Color actualValue = ObjectToFade.GetComponent<SpriteRenderer>().color;
            //Debug.Log(actualValue.a);
            ObjectToFade.GetComponent<SpriteRenderer>().color = new Color(actualValue.r, actualValue.g, actualValue.b, actualValue.a - fadeValue);
            if (actualTime >= timeToDie)
            {
            if (isCharacter)
                Destroy(this.gameObject);

            if (destroyAfter)
            {
                Destroy(transform.parent.parent.gameObject);
            }
            

            if(gameObject.transform.parent.name == "DeniedAttack" && gameObject.name == "Denied")
            {
                Destroy(transform.parent.gameObject);
            }

            if(OptionnalObjectToDestroy)
            {
                Destroy(OptionnalObjectToDestroy);
            }
            GetComponent<FadeOut>().enabled = false;
        }
    }
}
