using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround2 : MonoBehaviour
{
    public static BackGround2 instance;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
