using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    public static effect instance;
    public static GameObject 평타Effect;
    public GameObject 스노우볼Effect;
    public GameObject 아이스볼트Effect;
    public GameObject 얼음방패Effect;
    public GameObject 눈보라Effect;
    public GameObject 블리자드샤워Effect;
    public GameObject 바인딩Effect;
    public static float effectcool = 1f;
    public static float S1effectcool = 1f;
    public static float S2effectcool = 1f;
    public static float S3effectcool = 1f;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        평타Effect = GameObject.Find("타격이펙트");
        평타Effect.SetActive(false);
        스노우볼Effect.SetActive(false);
        아이스볼트Effect.SetActive(false);
        얼음방패Effect.SetActive(false);
        눈보라Effect.SetActive(false);
        블리자드샤워Effect.SetActive(false);
        바인딩Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (effectcool > 0)
        {
            effectcool -= Time.deltaTime;

        }
        if (effectcool < 0)
        {
            평타Effect.SetActive(false);

            effectcool = 0;
        }


        if (S1effectcool > 0)
        {
            S1effectcool -= Time.deltaTime;
        }
        if (S1effectcool < 0)
        {
            스노우볼Effect.SetActive(false);
            아이스볼트Effect.SetActive(false);
            S1effectcool = 0;
        }
        if (S2effectcool > 0)
        {
            S2effectcool -= Time.deltaTime;
        }
        if (S2effectcool < 0)
        {
            얼음방패Effect.SetActive(false);
            눈보라Effect.SetActive(false);
            S2effectcool = 0;
        }
        if (S3effectcool > 0)
        {
            S3effectcool -= Time.deltaTime;
        }
        if (S3effectcool < 0)
        {
            블리자드샤워Effect.SetActive(false);
            바인딩Effect.SetActive(false);
            S3effectcool = 0;
        }
    }

    public void startEffect(string 종류)
    {
        if (종류 == "평타")
        {
            평타Effect.SetActive(true);
            effectcool = 0.5f;
        }
        if (종류 == "스노우볼")
        {

            스노우볼Effect.SetActive(true);
            S1effectcool = 2f;
        }
        if (종류 == "아이스볼트")
        {

            아이스볼트Effect.SetActive(true);
            S1effectcool = 2.2f;
        }
        if (종류 == "얼음방패")
        {

            얼음방패Effect.SetActive(true);
            S2effectcool = 3.0f;
        }
        if (종류 == "눈보라")
        {

            눈보라Effect.SetActive(true);
            S2effectcool = 3.0f;
        }
        if (종류 == "블리자드샤워")
        {
            블리자드샤워Effect.SetActive(true);
            S3effectcool = 2.0f;

            
        }
        if (종류 == "바인딩")
        {
            바인딩Effect.SetActive(true);
            S3effectcool = 1.5f;
        }
    }
}
