using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    private Text test;
    public static string 설명창;

    void Start()
    {
        test = GetComponent<Text>();
        //StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        test.text = 설명창;
    }

   /*public IEnumerator Blink()
    {
        while(true)
        {
            yield return new WaitForSeconds(.1f);
            test.text = "";
            yield return new WaitForSeconds(.1f);
            
        }
    }*/
 
}
