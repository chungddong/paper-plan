using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHATTEST : MonoBehaviour

    
{
    public Text text;

    public float speed = 2f;
    public float yMove = 1f;
    public float destroytime = 1f;
    
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "chat")
        {
            this.transform.Translate(new Vector2(0, +yMove));
        }
    }
}
