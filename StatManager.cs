using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public static StatManager Statinstance;
    public int maxHP = 0;
    public  int HP = 0;
    public int 기력 = 0;
    public int max기력 = 0;
    public int 공격력 = 0;
    public int 마법력 = 0;
    public int 방어력 = 0;
    public int 레벨 = 1;
    public int EXP = 0;
    public int MaxEXP = 99;

    public int is렙업수 = 0;

    public bool is레벨업 = false;

    public Slider HpSlider;
    public Slider MpSlider;
    public Slider EXPSlider;

    public int 캐릭터ID = 0;

    bool is스킬1습득 =false;
    bool is스킬2습득 = false;
    bool is스킬3습득 = false;


    // Start is called before the first frame update
    void Start()
    {
      
        
        Statinstance = this;
        캐릭터ID = 1;
        
        if (gameObject.tag == "현우")
        {
            maxHP = 100;
            공격력 = 20;
        }
        if(캐릭터ID ==1)
        {
            maxHP = 130;
            max기력 = 6;
            공격력 = 13;
            
        }
        HP = maxHP;
        MaxEXP = 레벨 + 3;

    }

    // Update is called once per frame
    void Update()
    {
        if(is스킬1습득 == false)
        {
            choice.instance.스킬선택(1);
            is스킬1습득 = true;
        }
        if (레벨 >= 7 && is스킬2습득 == false && Playbutton.instance.is전투 == false && GameManager.GameManagerinstance.istagOpen == false && Inventory.instance.isopen == false && Equip.instance.isopen == false && choice.instance.isOpen == false && choice.instance.isOpen == false&& is레벨업 == false)
        {
            choice.instance.스킬선택(2);
            is스킬2습득 = true;
        }
        if (레벨 >= 15 && is스킬3습득 == false && Playbutton.instance.is전투 == false && GameManager.GameManagerinstance.istagOpen == false && Inventory.instance.isopen == false && Equip.instance.isopen == false && choice.instance.isOpen == false && choice.instance.isOpen == false && is레벨업 == false)
        {
            choice.instance.스킬선택(3);
            is스킬3습득 = true;
        }

        if (HP <= 0 )
        {
            HP = 0;
            GameManager.GameManagerinstance.사망();
        }
        if(HP > maxHP)
        {
            HP = maxHP;
        }

        if(EXP>= MaxEXP)
        {
            EXP -= MaxEXP;
            maxHP += 3;
            is렙업수++;
            HP = maxHP;
            is레벨업 = true;
            레벨++;
            Debug.Log("레벨업");
        }

        if(기력>max기력)
        {
            기력 = max기력;
        }

        if (is레벨업 == true)
        {
            if (Playbutton.instance.is전투 == false && GameManager.GameManagerinstance.istagOpen == false && Inventory.instance.isopen == false && Equip.instance.isopen == false && choice.instance.isOpen == false && is렙업수 >0)
            {
               
                choice.instance.스텟선택();
                is렙업수--;
                
                if(is렙업수 == 0)
                {
                    is레벨업 = false;
                }
               
            }
        }
      

        HpSlider.maxValue = maxHP;
        HpSlider.value = HP;

        MpSlider.maxValue = max기력;
        MpSlider.value = 기력;

        MaxEXP = 레벨 + 6;
        EXPSlider.maxValue = MaxEXP;
        EXPSlider.value = EXP;

    }
    
}  
