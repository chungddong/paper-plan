using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager instance; 
    public Text 내체력;
    public Text 내기력;
    public Text 레벨;
    public Text 제한턴Text;
    public Text 진행량Text;

   

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name=="내체력Text")
        {
            내체력.text = StatManager.Statinstance.HP + " / " + StatManager.Statinstance.maxHP;  
        }
        if (gameObject.name == "내기력Text")
        {
            내기력.text = StatManager.Statinstance.기력 + " / " + StatManager.Statinstance.max기력;
        }
        if (gameObject.name == "레벨Text")
        {
            레벨.text = StatManager.Statinstance.레벨 + "";
        }
     
        if(gameObject.name == "진행량Text")
        {
            진행량Text.text = Playbutton.instance.진행량 + "/" + Playbutton.instance.Max진행량;
        }

        if(gameObject.name ==  "제한턴Text")
        {
            제한턴Text.text = Playbutton.instance.제한턴 + " 턴";
        }

        if (Playbutton.instance.제한턴 < 0)
        {
            Playbutton.instance.제한턴 = 0;
        }
        if(Playbutton.instance.진행량 > Playbutton.instance.Max진행량)
        {
            Playbutton.instance.진행량 = Playbutton.instance.Max진행량;
        }
    }
}
