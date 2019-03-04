using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle1 : MonoBehaviour
{
    bool 숨기기 = false;
    public Image image;
    public Image image2;
    public Image image3;
    public Image image4;
    public GameObject 파티클;
    public Button button;
    public Button button2;
    public Button button3;
    public Button button4;
    public float coolTime;
    public float S1coolTime;
    public float S2coolTime;
    public float S3coolTime;
    public float leftTime;
    public float S1leftTime;
    public float S2leftTime;
    public float S3leftTime;
    public bool MyTurn = true;
    public bool MonsterTurn = false;
    public static Battle1 battle ;
    public bool isMyTurn = true;

    public bool 스노우볼 = false;
    public bool 스노우볼버프 = false;
    public bool 아이스볼트 = false;
    public bool 얼법강화 = false;
    public bool 얼음방패 = false;
    public float 얼음방패지속시간 = 0;
    public bool 눈보라 = false;
    public float 눈보라버프시간 = 0;
    public bool 눈보라버프 = false;
    public bool 블리자드샤워 = false;
    public bool 바인딩 = false;
    


    int 기본공격확률 = 0;
    public int 데미지 = 0;
    //public GameObject 나의턴이미지;



    void Start()
    {
        battle = this;

    }

    // Update is called once per frame
    void Update()
    {
        
         if (leftTime > 0)// 쿨타임 함수
         {

             leftTime -= Time.deltaTime;
            if (button)
                button.enabled = false;


            if (leftTime < 0)
             {
                 leftTime = 0;
                coolTime = 0;
                 if (button)
                     button.enabled = true;// 버튼 기능 가능
                     

             }

             float ratio = 1.0f - (leftTime / coolTime);
            if (image)
                        image.fillAmount = ratio;
                   
         }

        if (S1leftTime > 0)// 스킬1쿨타임 함수
        {

            S1leftTime -= Time.deltaTime;

            if (button2)
                button2.enabled = false;

            if (S1leftTime < 0)
            {
                S1leftTime = 0;
                S1coolTime = 0;
                if (button2)
                    button2.enabled = true;

            }

            float S1ratio = 1.0f - (S1leftTime / S1coolTime);
            
            if (image2)
                image2.fillAmount = S1ratio;
        }
        if (S2leftTime > 0)// 스킬1쿨타임 함수
        {

            S2leftTime -= Time.deltaTime;

            if (button3)
                button3.enabled = false;

            if (S2leftTime < 0)
            {
                S2leftTime = 0;
                S2coolTime = 0;
                if (button3)
                    button3.enabled = true;

            }

            float S2ratio = 1.0f - (S2leftTime / S2coolTime);

            if (image3)
                image3.fillAmount = S2ratio;
        }
        if (S3leftTime > 0)// 스킬1쿨타임 함수
        {

            S3leftTime -= Time.deltaTime;

            if (button4)
                button4.enabled = false;

            if (S3leftTime < 0)
            {
                S3leftTime = 0;
                S3coolTime = 0;
                if (button4)
                    button4.enabled = true;

            }

            float S3ratio = 1.0f - (S3leftTime / S3coolTime);

            if (image4)
                image4.fillAmount = S3ratio;
        }
        /* if (Playbutton.instance.is전투 == true)
         {
             if (MyTurn == true)
             {
                 if (button)
                     button.enabled = true;
                 if (button2)
                     button2.enabled = true;
                 if (isMyTurn == true)
                 {
                     isMyTurn = false;
                     if (image)
                         image.fillAmount = 1;
                     if (image2)
                         image2.fillAmount = 1;
                     //나의턴이미지.SetActive(true);
                     //Invoke("MyturnOff", 1f);
                     Debug.Log("나의 턴!");

                 }
             }
         }*/
        if (얼음방패지속시간 > 0)
        {
            얼음방패지속시간 -= Time.deltaTime;
            if(얼음방패지속시간 <0)
            {
                얼음방패지속시간 = 0;
                StatManager.Statinstance.방어력 -= StatManager.Statinstance.마법력;
            }
        }
        if(눈보라버프시간 >0)
        {
            눈보라버프시간 -= Time.deltaTime;
            if(눈보라버프시간<=0 && 눈보라버프 ==true)
            {
                눈보라버프시간 = 0;
                눈보라버프 = false;
            }
        }

    }
    void MyturnOff()
    {
       // 나의턴이미지.SetActive(false);
    }

    public void 평타Click()
    {

        if (Playbutton.instance.is전투 == true)
        {
            if(숨기기 == true)
            {
                /*if ( MyTurn == true)
           {
               Playbutton.instance.제한턴 -= 1;
               기본공격확률 = Random.Range(1, 21);
               MonsterShake.ShakeMonster();
               if (기본공격확률 <= 17 && 기본공격확률 >0)
               {
                   effect.instance.startEffect("평타");//이팩트실행

                   데미지 = StatManager.Statinstance.공격력;
                   MonserList.instance.몬스터데미지주기(데미지);
                   DamageTextManager.instance.내공격Text(1);
                   text.설명창 = "기본공격!";
               }

               if (기본공격확률 >=18 && 기본공격확률 <= 19)
               {
                   effect.instance.startEffect("평타");//이팩트실행

                   데미지 = StatManager.Statinstance.공격력 * 2;
                   MonserList.instance.몬스터데미지주기(데미지);
                   DamageTextManager.instance.내공격Text(2);
                   text.설명창 = "기본공격! 치명타!!";
               }

               if(기본공격확률 == 20)
               {
                   effect.instance.startEffect("평타");//이팩트실행

                   데미지 = 0;
                   MonserList.instance.몬스터데미지주기(데미지);
                   DamageTextManager.instance.내공격Text(3);
                   text.설명창 = "기본공격! 빗나갔다!";
               }

               StatManager.Statinstance.기력++;




               image.fillAmount = 0;
               MyTurn = false;
               Invoke("MonsterTurns", 1.3f);

               //coolTime = 1f; // 여기서 쿨타임 변경
           }*/
            }// 턴제 스크립트 숨기기

            기본공격확률 = Random.Range(1, 21);
            MonsterShake.ShakeMonster();
            if (기본공격확률 <= 17 && 기본공격확률 > 0)
            {
                effect.instance.startEffect("평타");//이팩트실행

                데미지 = StatManager.Statinstance.공격력;
                if(눈보라버프 == true)
                {
                    데미지 = 데미지 += StatManager.Statinstance.마법력 * 1 / 5;
                }
                MonserList.instance.몬스터데미지주기(데미지);
                DamageTextManager.instance.내공격Text(1);
                //text.설명창 = "기본공격!";
            }

            if (기본공격확률 >= 18 && 기본공격확률 <= 19)
            {
                effect.instance.startEffect("평타");//이팩트실행

                데미지 = StatManager.Statinstance.공격력 * 2;
                if (눈보라버프 == true)
                {
                    데미지 = 데미지 += StatManager.Statinstance.마법력 * 1 / 5;
                }
                MonserList.instance.몬스터데미지주기(데미지);
                DamageTextManager.instance.내공격Text(2);
                //text.설명창 = "기본공격! 치명타!!";
            }

            if (기본공격확률 == 20)
            {
                effect.instance.startEffect("평타");//이팩트실행

                데미지 = 0;
                MonserList.instance.몬스터데미지주기(데미지);
                DamageTextManager.instance.내공격Text(3);
                //text.설명창 = "기본공격! 빗나갔다!";
            }

            StatManager.Statinstance.기력++;




            image.fillAmount = 0;
            //MyTurn = false;
            //Invoke("MonsterTurns", 1.3f);

            coolTime = 2f; // 여기서 쿨타임 변경
            if(S1leftTime <=0)
            {
                S1coolTime += 1f;
                S1leftTime = S1coolTime;
            }
            if (S2leftTime <= 0)
            {
                S2coolTime += 1f;
                S2leftTime = S1coolTime;
            }
            if (S3leftTime <= 0)
            {
                S3coolTime += 1f;
                S3leftTime = S1coolTime;
            }
           
            if (button)
                button.enabled = false; // 버튼 기능 해지

            leftTime = coolTime;
        }
        else
        {
            Debug.LogError("전투가 시작되지 않았습니다.");
        }
    }
    public void 스킬1Click()
    {
        if(스노우볼 == true)
        {
            if (Playbutton.instance.is전투 == true)
            {
                if (StatManager.Statinstance.기력 >= 2)
                {

                    
                    effect.instance.startEffect("스노우볼");//이팩트실행
                    MonsterShake.ShakeMonster();
                    눈보라버프 = true;
                    눈보라버프시간 = 3;
                    데미지 = 10 + StatManager.Statinstance.마법력 /2;
                    
                    MonserList.instance.몬스터데미지주기(데미지);
                    DamageTextManager.instance.내공격Text(1);
                    if(얼법강화 == true)
                    {
                        스노우볼버프 = true;
                    }




                    image2.fillAmount = 0;
                    S1coolTime = 2f;
                    // MyTurn = false;
                    //Invoke("MonsterTurns", 1.3f);
                    StatManager.Statinstance.기력 -= 3;

                    if (button2)
                        button2.enabled = false; // 버튼 기능 해지
                    S1leftTime = S1coolTime;
                    if (leftTime <= 0)
                    {
                        coolTime += 1f;
                        leftTime = coolTime;
                    }
                    if (S2leftTime <= 0)
                    {
                        S2coolTime += 1f;
                        S2leftTime = S1coolTime;
                    }
                    if (S3leftTime <= 0)
                    {
                        S3coolTime += 1f;
                        S3leftTime = S1coolTime;
                    }
                }
                else
                {
                    text.설명창 = "기력이 부족합니다.";
                }
            }
       
        }
        if (아이스볼트 == true)
        {
            if (Playbutton.instance.is전투 == true)
            {
                if (StatManager.Statinstance.기력 >= 5)
                {

                   
                    effect.instance.startEffect("아이스볼트");//이팩트실행
                    MonsterShake.ShakeMonster();

                    데미지 = 15 + StatManager.Statinstance.마법력 * 3 / 5;
                    if(얼법강화 == true)
                    {
                        데미지 = 35 + StatManager.Statinstance.마법력 * 4 / 5;
                    }
                    MonserList.instance.몬스터데미지주기(데미지);
                    DamageTextManager.instance.내공격Text(1);





                    image2.fillAmount = 0;
                    S1coolTime = 7f;
                    // MyTurn = false;
                    //Invoke("MonsterTurns", 1.3f);
                    StatManager.Statinstance.기력 -= 5;

                    if (button2)
                        button2.enabled = false; // 버튼 기능 해지
                    S1leftTime = S1coolTime;
                    if (leftTime <= 0)
                    {
                        coolTime += 1f;
                        leftTime = coolTime;
                    }
                    if (S2leftTime <= 0)
                    {
                        S2coolTime += 1f;
                        S2leftTime = S1coolTime;
                    }
                    if (S3leftTime <= 0)
                    {
                        S3coolTime += 1f;
                        S3leftTime = S1coolTime;
                    }
                }
                else
                {
                    text.설명창 = "기력이 부족합니다.";
                }
            }

        }
    }
    public void 스킬2Click()
    {
        if (얼음방패 == true)
        {
            if (Playbutton.instance.is전투 == true)
            {
                if (StatManager.Statinstance.기력 >= 5)
                {

                  
                    effect.instance.startEffect("얼음방패");//이팩트실행
                    StatManager.Statinstance.방어력 += StatManager.Statinstance.마법력;
                    얼음방패지속시간 = 3;




                    image3.fillAmount = 0;
                    S2coolTime = 5f;
                    // MyTurn = false;
                    //Invoke("MonsterTurns", 1.3f);
                    StatManager.Statinstance.기력 -= 5;

                    if (button3)
                        button3.enabled = false; // 버튼 기능 해지
                    S2leftTime = S2coolTime;
                    if (leftTime <= 0)
                    {
                        coolTime += 1f;
                        leftTime = coolTime;
                    }
                    if (S1leftTime <= 0)
                    {
                        S1coolTime += 1f;
                        S1leftTime = S1coolTime;
                    }
                    if (S3leftTime <= 0)
                    {
                        S3coolTime += 1f;
                        S3leftTime = S1coolTime;
                    }
                }
                else
                {
                    text.설명창 = "기력이 부족합니다.";
                }
            }

        }
        if (눈보라 == true)
        {
            if (Playbutton.instance.is전투 == true)
            {
                if (StatManager.Statinstance.기력 >= 6)
                {


                    effect.instance.startEffect("눈보라");//이팩트실행
                    MonsterShake.ShakeMonster();
                    눈보라버프 = true;
                    눈보라버프시간 = 3;
                    데미지 = 10 + StatManager.Statinstance.마법력 * 2 / 5;
                    if(스노우볼버프 == true)
                    {
                        데미지 = 데미지* 6 / 5;
                        스노우볼버프 = false;
                    }
                    MonserList.instance.몬스터데미지주기(데미지);
                    DamageTextManager.instance.내공격Text(1);
                  




                    image3.fillAmount = 0;
                    S2coolTime = 8f;
                    // MyTurn = false;
                    //Invoke("MonsterTurns", 1.3f);
                    StatManager.Statinstance.기력 -= 6;

                    if (button3)
                        button3.enabled = false; // 버튼 기능 해지
                    S2leftTime = S2coolTime;
                    if (leftTime <= 0)
                    {
                        coolTime += 1f;
                        leftTime = coolTime;
                    }
                    if (S3leftTime <= 0)
                    {
                        S3coolTime += 1f;
                        S3leftTime = S1coolTime;
                    }
                    if (S1leftTime <= 0)
                    {
                        S1coolTime += 1f;
                        S1leftTime = S1coolTime;
                    }
                }
                else
                {
                    text.설명창 = "기력이 부족합니다.";
                }
            }

        }
    }
    public void 스킬3Click()
    {
        if (블리자드샤워 == true)
        {
            if (Playbutton.instance.is전투 == true)
            {
                if (StatManager.Statinstance.기력 >= 10)
                {

                    effect.instance.startEffect("블리자드샤워");//이팩트실행
                    MonsterShake.ShakeMonster();
                   
                    데미지 = StatManager.Statinstance.마법력 * 8;
                    if (스노우볼버프 == true)
                    {
                        데미지 = 데미지 * 6 / 5;
                        스노우볼버프 = false;
                    }
                    MonserList.instance.몬스터데미지주기(데미지);
                    DamageTextManager.instance.내공격Text(1);


                    image4.fillAmount = 0;
                    S3coolTime = 20f;
                    // MyTurn = false;
                    //Invoke("MonsterTurns", 1.3f);
                    StatManager.Statinstance.기력 -= 10;

                    if (button4)
                        button4.enabled = false; // 버튼 기능 해지
                    S3leftTime = S3coolTime;
                    if (leftTime <= 0)
                    {
                        coolTime += 1f;
                        leftTime = coolTime;
                    }
                    if (S1leftTime <= 0)
                    {
                        S1coolTime += 1f;
                        S1leftTime = S1coolTime;
                    }
                    if (S2leftTime <= 0)
                    {
                        S2coolTime += 1f;
                        S2leftTime = S1coolTime;
                    }
                }
                else
                {
                    text.설명창 = "기력이 부족합니다.";
                }
            }

        }
        if (바인딩 == true)
        {
            if (Playbutton.instance.is전투 == true)
            {
                if (StatManager.Statinstance.기력 >= 5)
                {


                    effect.instance.startEffect("바인딩");//이팩트실행
                    MonserAttackManager.instance.Mattack += 6;
                 
                 





                    image4.fillAmount = 0;
                    S3coolTime = 60f;
                    // MyTurn = false;
                    //Invoke("MonsterTurns", 1.3f);
                    StatManager.Statinstance.기력 -= 5;

                    if (button4)
                        button4.enabled = false; // 버튼 기능 해지
                    S3leftTime = S3coolTime;
                    if (leftTime <= 0)
                    {
                        coolTime += 1f;
                        leftTime = coolTime;
                    }
                    if (S2leftTime <= 0)
                    {
                        S2coolTime += 1f;
                        S2leftTime = S1coolTime;
                    }
                    if (S1leftTime <= 0)
                    {
                        S1coolTime += 1f;
                        S1leftTime = S1coolTime;
                    }
                }
                else
                {
                    text.설명창 = "기력이 부족합니다.";
                }
            }

        }
    }
    public void MonsterTurns()
    {

        MonsterTurn = true;
    }
   
 public void 버튼활성화()
    {
        if (button)
            button.enabled = true;
        if (button2)
            button2.enabled = true;
        if (button3)
            button2.enabled = true;
        if (button4)
            button2.enabled = true;
    }

    public void 스킬활성화(int 스킬번호, int 스킬선택번호)
    {
        if(StatManager.Statinstance.캐릭터ID == 1)//얼음법사라면
        {
            if(스킬번호 ==1)
            {
                if(스킬선택번호 ==1)
                {
                    스노우볼 = true;
                }
                if(스킬선택번호==2)
                {
                    아이스볼트 = true;
                }
            }
            if (스킬번호 == 2)
            {
                if (스킬선택번호 == 1)
                {
                    얼음방패 = true;
                }
                if (스킬선택번호 == 2)
                {
                    눈보라 = true;
                }
            }
            if (스킬번호 == 3)
            {
                if (스킬선택번호 == 1)
                {
                    블리자드샤워 = true;
                }
                if (스킬선택번호 == 2)
                {
                    바인딩 = true;
                }
            }
        }
    }
}
