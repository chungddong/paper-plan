using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public SpriteRenderer white;
    public SpriteRenderer black;
    public Color color;

    bool isfadeIn = false;
    bool isfadeOut = false;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    public static Fade instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if(isfadeOut == true)
        {
            color = black.color;
            color.a += 2* Time.deltaTime;
            black.color = color;
            
            if(color.a >= 1)
            {
                isfadeOut = false;
            }
        }

        if(isfadeIn == true)
        {
            color = black.color;
            color.a -= 2*Time.deltaTime;
            black.color = color;
            if(color.a <= 0)
            {
                isfadeIn = false;
            }
        }
    }
    // Start is called before the first frame update
    public void FadeOut()
    {
        isfadeOut = true;

    }
   /* IEnumerator FadeOutCoroutine(float speed)
    {
        color = black.color;

        while(color.a<1f)
        {
            color.a += speed;
            black.color = color;
            yield return waitTime;
        }
    }*/

    public void FadeIn()
    {

        isfadeIn = true;
    }
    /*IEnumerator FadeInCoroutine(float speed)
    {
        color = black.color;

        while (color.a > 0f)
        {
            color.a -= speed;
            black.color = color;
            yield return waitTime;
        }
    }*/
}
