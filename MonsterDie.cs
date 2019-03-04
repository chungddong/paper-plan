using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    public static MonsterDie instance;
    public int 죽은몬스터번호 = 0;
    public bool is드랍 = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Playbutton.instance.is전투 == true)
        {
            if (MonserList.instance.is몬스터Die == true)
            {
                if (is드랍 == true)
                {

                    Battle1.battle.leftTime = 0;
                    Battle1.battle.S1leftTime = 0;
                    Battle1.battle.coolTime = 0;
                    Battle1.battle.S1coolTime = 0;
                    몬스터드랍경험치();
                    MonserAttackManager.instance.몬스터스킬 = false;
                    // MonsterHpManager.isMDie = true;//나중에 탐색버튼 누를시 false로 바꾸자 현민아
                    Debug.Log("경험치 획득");
                }

            }
        }
    }

    public void 몬스터드랍경험치()
    {
        if (죽은몬스터번호 == 10)//유성
        {
            StatManager.Statinstance.EXP += 5;
            is드랍 = false;
        }
        if (죽은몬스터번호 == 11)//핑크
        {
            StatManager.Statinstance.EXP += 2;
            is드랍 = false;
        }
        if (죽은몬스터번호 == 12)//그린
        {
            StatManager.Statinstance.EXP += 2;
            is드랍 = false;
        }
        if (죽은몬스터번호 == 13)//블루
        {
            StatManager.Statinstance.EXP += 2;
            is드랍 = false;
        }
        if (죽은몬스터번호 == 101)//보스플
        {
            StatManager.Statinstance.EXP += 20;
            is드랍 = false;
        }
        if (죽은몬스터번호 == 14)//리프불
        {
            StatManager.Statinstance.EXP += 3;
            is드랍 = false;
        }
        if (죽은몬스터번호 == 15)//리프불
        {
            StatManager.Statinstance.EXP += 3;
            is드랍 = false;
        }
        if (죽은몬스터번호 == 20)
        {
            StatManager.Statinstance.EXP += 3;
            is드랍 = false;
        }

    }
}
