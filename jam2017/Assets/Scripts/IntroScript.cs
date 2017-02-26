using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroScript : MonoBehaviour {

    string story = "-- The  year  is  2048 -- \n Mankind  lives  under  an  absolute\n  totalitarian  regime  lead  by\n\n--  Supreme  Leader  Felix  Kjellberg --";

    public Image mainImage;

    public Text textBox ;

    public int aliveFrames;



    void Start()
    {
        aliveFrames = 0;
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        textBox.text = story.Substring(0, Mathf.Min(aliveFrames / 3, story.Length));
        aliveFrames++;

        if (aliveFrames == 441)
        {
            story = "Freedom  of  thought  is  a  thing  of  the  past\nHowever,  four  brave  rebels\nrise  up  to  free  mankind";
            aliveFrames = 0;
            StartCoroutine(LoadMain());
        }
    }

    IEnumerator FadeIn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            mainImage.color = new Color(mainImage.color.r, mainImage.color.g, mainImage.color.b, mainImage.color.a + 0.001f);
        }
    }

    IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Title");
    }
}
