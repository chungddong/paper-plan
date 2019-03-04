using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageTextManager : MonoBehaviour
{
    public static DamageTextManager instance;
 
    public Text 몬스터데미지;
    public int 몬스터데미지수;
    public Text 내데미지;
    Color color;
    Color color2;
  

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Start is called before the first frame update
    void Start()
    {

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void 내공격Text(int 공격판정)
    {
        color = 내데미지.color;
        color.a = 1f;
        내데미지.color = color;
        Invoke("내코루틴실행", 1.0f);
        if(공격판정 ==1)
        {
            내데미지.text = "-" + Battle1.battle.데미지;
        }
        if (공격판정 == 2)
        {
            내데미지.text = "치명타! -" + Battle1.battle.데미지;
        }
        if (공격판정 == 3)
        {
            내데미지.text = "Miss";
        }

        //color.a -= Time.deltaTime;

    }
    public void 내코루틴실행()
    {

        StartCoroutine(OffMyDamage(0.03f));
    }
    IEnumerator OffMyDamage(float _speed)
    {
        color = 내데미지.color;
        while(color.a > 0f)
        {
            color.a -= _speed;
            내데미지.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }
 

    public void 몬스터공격Text(int 공격판정)
    {
        color2 = 몬스터데미지.color;
        color2.a = 1f;
        Invoke("적코루틴실행", 1.0f);
        몬스터데미지.color = color2;

        if(Playbutton.instance.몬스터번호 ==10)
        {
            몬스터데미지수 = MonserAttackManager.instance.유성몬스터데미지;
        }
        if (Playbutton.instance.몬스터번호 == 11)
        {
            몬스터데미지수 = MonserAttackManager.instance.핑크플몬스터데미지;
        }
        if (Playbutton.instance.몬스터번호 == 12)
        {
            몬스터데미지수 = MonserAttackManager.instance.그린플몬스터데미지;
        }
        if (Playbutton.instance.몬스터번호 == 13)
        {
            몬스터데미지수 = MonserAttackManager.instance.블루플몬스터데미지;
        }
        if (Playbutton.instance.몬스터번호 == 14)
        {
            몬스터데미지수 = MonserAttackManager.instance.리프불몬스터데미지;
        }
        if (Playbutton.instance.몬스터번호 == 15)
        {
            몬스터데미지수 = MonserAttackManager.instance.리프라이언몬스터데미지;
        }
        if (Playbutton.instance.몬스터번호 == 101)
        {
            몬스터데미지수 = MonserAttackManager.instance.보스플몬스터데미지;
        }
        if (Playbutton.instance.몬스터번호 == 20)
        {
            몬스터데미지수 = MonserAttackManager.instance.용암정령몬스터데미지;
        }
        //color2.a -= Time.deltaTime;
        if (공격판정 ==1)
        {
            몬스터데미지.text = "-" + 몬스터데미지수;
        }
        if (공격판정 == 2)
        {
            몬스터데미지.text = "치명타!-" + 몬스터데미지수;
        }
        if (공격판정 == 3)
        {
            몬스터데미지.text = "Miss" ;
        }
    



    }
    public void 적코루틴실행 ()
    {
        StartCoroutine(OffMonsterDamage(0.03f));
    }
    IEnumerator OffMonsterDamage(float _speed)
    {
        color2 = 몬스터데미지.color;
        while (color2.a > 0f)
        {
            color2.a -= _speed;
            몬스터데미지.color = color2;
            yield return new WaitForSeconds(0.01f);
        }
    }




}
