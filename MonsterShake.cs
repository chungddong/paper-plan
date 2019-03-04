using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShake : MonoBehaviour
{
    Vector3 OriginalPos;
    public static float Mshake = 0f;
    public static bool MonsterShaking;
    public static float ShakeAmount = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        MonsterShaking = false;
        OriginalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(MonsterShaking)
        {
            if (Mshake > 0f)
            {
                gameObject.transform.position = OriginalPos + Random.insideUnitSphere * ShakeAmount;
                ShakeAmount = 0.2f;
                Mshake -= Time.deltaTime;
            }
            else
            {
                Mshake = 0f;
                MonsterShaking = false;
                gameObject.transform.position = OriginalPos;
            }
        }
    }
    public static void ShakeMonster()
    {
       
            Mshake = 0.5f;
            MonsterShaking = true;
        
    }
}
