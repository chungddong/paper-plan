using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 용암정령HP : MonoBehaviour
{
    public static 용암정령HP instance;
    public int maxMHP = 0;
    public int MHP = 0;
    public static int 몬공격력 = 0;
    public static bool isMDie = false;

    public Slider MHpSlider;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        몬스터체력초기화();
    }
    public void 몬스터체력초기화()
    {
        if (Playbutton.instance.몬스터번호 == 20)
        {
            maxMHP = 110 + StatManager.Statinstance.레벨 * 8;
            몬공격력 = 4 + StatManager.Statinstance.레벨 /3;

        }
        MHP = maxMHP;
    }

    // Update is called once per frame
    void Update()
    {
        MHpSlider.maxValue = maxMHP;

        MHpSlider.value = MHP;

        if (MHP <= 0)
        {
            if (Playbutton.instance.몬스터번호 == 20)
            {
                MonsterDie.instance.죽은몬스터번호 = 20;
                MonserList.instance.is몬스터Die = true;
            }


        }
    }
}
