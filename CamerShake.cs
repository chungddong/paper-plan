using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    Vector3 OriginalPos;
    public static float shake = 0f;
    public float shakeAmount = 0.3f;
    public static bool CameraShaking;

    
    void Start()
    {
        CameraShaking = false;
        OriginalPos = gameObject.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraShaking)
        {
            if(effect.instance.스노우볼Effect.activeSelf == false && effect.instance.아이스볼트Effect.activeSelf == false)
            {
                if (shake > 0f)
                {
                    gameObject.transform.position = OriginalPos + Random.insideUnitSphere * shakeAmount;

                    shake -= Time.deltaTime;
                }
                else
                {
                    shake = 0f;
                    CameraShaking = false;
                    gameObject.transform.position = OriginalPos;
                }
            }
            else
            {
               
                shake = 0f;
                CameraShaking = false;
                gameObject.transform.position = OriginalPos;
            }
            
        }
    }

    public static void ShakeCamera ()
    {
        shake = 0.7f;
        CameraShaking = true;
    }
}
