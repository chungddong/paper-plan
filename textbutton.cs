using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textbutton : MonoBehaviour
{
    public static string helloworld;

    void Start()
    {
        helloworld = "";
    }

    public void Monster()
    {
        helloworld = "몬스터가 나타났다";
    }

    public void Item()
    {
        helloworld = "아이템 획득";
    }

    public void test()
    {
        Debug.Log("누름");
    }
}
