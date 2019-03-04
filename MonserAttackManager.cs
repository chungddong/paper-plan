using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonserAttackManager : MonoBehaviour
{
    public static MonserAttackManager instance;
    public int 유성몬스터데미지;
    public int 핑크플몬스터데미지;
    public int 그린플몬스터데미지;
    public int 블루플몬스터데미지;
    public int 보스플몬스터데미지;
    public int 리프불몬스터데미지;
    public int 리프라이언몬스터데미지;
    public int 용암정령몬스터데미지;

    public float Mattack = 1f;
    float Mcool ;// 몬스터 쿨타임
    public Animator animator;

    int 공격확률 = 0;
    int 추가데미지 = 0;

    public bool 몬스터스킬 = false;
    


    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        
    }

   
    void Update()
    {
        if (Playbutton.instance.is전투 == true)
        {
            if (Mattack > 0)// 몬스터 공격함수
            {
                animator.SetBool("attack", false);
                Mattack -= Time.deltaTime;

                if (Mattack < 0)
                {



                    if (Playbutton.instance.몬스터번호 == 10)
                    {

                        공격확률 = Random.Range(1, 21);
                        if (공격확률 <= 16 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5);
                            유성몬스터데미지 = MonsterHpManager.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (유성몬스터데미지 < 1)
                            {
                                유성몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 유성몬스터데미지;// 몬스터 데미지
                            
                        }
                        if (공격확률 >= 17 && 공격확률 <= 18)
                        {
                            추가데미지 = Random.Range(0, 5);
                            유성몬스터데미지 = (MonsterHpManager.몬공격력 + 추가데미지) * 2 - StatManager.Statinstance.방어력 / 3;
                            if (유성몬스터데미지 < 1)
                            {
                                유성몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 유성몬스터데미지;// 몬스터 데미지
                            
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            유성몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);
                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 유성몬스터데미지;// 몬스터 데미지
                            
                        }
                        Mcool = 3f;
                    }//유성


                    if (Playbutton.instance.몬스터번호 == 11)
                    {
                        공격확률 = Random.Range(1, 21);
                        if (공격확률 <= 16 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5);
                            핑크플몬스터데미지 = 핑크플라워HP.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (핑크플몬스터데미지 < 1)
                            {
                                핑크플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 핑크플몬스터데미지;// 몬스터 데미지
                           
                        }
                        if (공격확률 >= 17 && 공격확률 <= 18)
                        {
                            추가데미지 = Random.Range(0, 5);
                            핑크플몬스터데미지 = (핑크플라워HP.몬공격력 + 추가데미지) * 2 - StatManager.Statinstance.방어력 / 3;
                            if (핑크플몬스터데미지 < 1)
                            {
                                핑크플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 핑크플몬스터데미지;// 몬스터 데미지
                            
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            핑크플몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);
                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 핑크플몬스터데미지;// 몬스터 데미지
                            
                        }
                        Mcool = 3f;
                    }//핑크플라워

                    if (Playbutton.instance.몬스터번호 == 12)
                    {
                        공격확률 = Random.Range(1, 21);
                        if (공격확률 <= 16 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5);
                            그린플몬스터데미지 = 그린플라워hp.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (그린플몬스터데미지 < 1)
                            {
                                그린플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 그린플몬스터데미지;// 몬스터 데미지
                           
                        }
                        if (공격확률 >= 17 && 공격확률 <= 18)
                        {
                            추가데미지 = Random.Range(0, 5);
                            그린플몬스터데미지 = (그린플라워hp.몬공격력 + 추가데미지) * 2 - StatManager.Statinstance.방어력 / 3;
                            if (그린플몬스터데미지 < 1)
                            {
                                그린플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 그린플몬스터데미지;// 몬스터 데미지
                           
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            그린플몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);
                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 그린플몬스터데미지;// 몬스터 데미지
                            
                        }
                        Mcool = 2.5f;
                    }//그린플라워

                    if (Playbutton.instance.몬스터번호 == 13)
                    {
                        공격확률 = Random.Range(1, 21);
                        if (공격확률 <= 13 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5);
                            블루플몬스터데미지 = 블루플라워HP.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (블루플몬스터데미지 < 1)
                            {
                                블루플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 블루플몬스터데미지;// 몬스터 데미지
                           
                        }
                        if (공격확률 >= 14 && 공격확률 <= 18)
                        {
                            추가데미지 = Random.Range(0, 5);
                            블루플몬스터데미지 = (블루플라워HP.몬공격력 + 추가데미지) * 5 / 2;
                            if (블루플몬스터데미지 < 1)
                            {
                                블루플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 블루플몬스터데미지;// 몬스터 데미지
                            
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            블루플몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);

                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 블루플몬스터데미지;// 몬스터 데미지
                            
                        }
                        Mcool = 2f;
                    }//블루플라워(치명타확률 증가. 치명타 데미지 2.5배로 증가, 치명타 고정뎀)

                    if (Playbutton.instance.몬스터번호 == 101)
                    {
                        if (몬스터스킬 == false)
                        {
                            공격확률 = Random.Range(1, 21);
                        }

                        if (공격확률 <= 8 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5);
                            보스플몬스터데미지 = 보스플라워HP.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (보스플몬스터데미지 < 1)
                            {
                                보스플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 보스플몬스터데미지;// 몬스터 데미지
                            
                        }
                        if (몬스터스킬 == true)
                        {
                            추가데미지 = Random.Range(0, 5);
                            보스플몬스터데미지 = (보스플라워HP.몬공격력 + 추가데미지) * 5/2 - StatManager.Statinstance.방어력 / 3;
                            if (보스플몬스터데미지 < 1)
                            {
                                보스플몬스터데미지 = 1;

                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            text.설명창 = "몬스터의 스킬!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 보스플몬스터데미지;// 몬스터 데미지
                           
                            몬스터스킬 = false;
                        }
                        if (공격확률 <= 13 && 공격확률 >= 9)
                        {

                            몬스터스킬 = true;
                            MonsterShake.ShakeAmount = 0.5f;
                            MonsterShake.ShakeMonster();
                            text.설명창 = "몬스터가 무언가 준비하고있다...!";

                        }

                        if (공격확률 >= 14 && 공격확률 <= 18)
                        {
                            추가데미지 = Random.Range(0, 5);
                            보스플몬스터데미지 = (보스플라워HP.몬공격력 + 추가데미지) * 2 - StatManager.Statinstance.방어력 / 3;
                            if (보스플몬스터데미지 < 1)
                            {
                                보스플몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 보스플몬스터데미지;// 몬스터 데미지
                            
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            보스플몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);

                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -=보스플몬스터데미지;// 몬스터 데미지
                            
                        }
                        공격확률 = 0;
                        Mcool = 3f;
                    }//보스플라워
                    if (Playbutton.instance.몬스터번호 == 14)
                    {
                        공격확률 = Random.Range(1, 21);
                        if (공격확률 <= 16 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5);
                            리프불몬스터데미지 = 리프불HP.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (리프불몬스터데미지 < 1)
                            {
                                리프불몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 리프불몬스터데미지;// 몬스터 데미지
                           
                        }
                        if (공격확률 >= 17 && 공격확률 <= 18)
                        {
                            추가데미지 = Random.Range(0, 5);
                            리프불몬스터데미지 = (리프불HP.몬공격력 + 추가데미지) * 2 - StatManager.Statinstance.방어력 / 3;
                            if (리프불몬스터데미지 < 1)
                            {
                                리프불몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 리프불몬스터데미지;// 몬스터 데미지
                          
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            리프불몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);
                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 리프불몬스터데미지;// 몬스터 데미지
                            
                        }
                        Mcool = 3.5f;
                    }//리프불

                    if (Playbutton.instance.몬스터번호 == 20)
                    {
                        공격확률 = Random.Range(1, 21);
                        if (공격확률 <= 10 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5) + StatManager.Statinstance.마법력 / 15;
                            용암정령몬스터데미지 = 용암정령HP.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (용암정령몬스터데미지 < 1)
                            {
                                용암정령몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 용암정령몬스터데미지;// 몬스터 데미지
                           
                        }
                        if (공격확률 >= 11 && 공격확률 <= 18)
                        {
                            추가데미지 = Random.Range(0, 5) + StatManager.Statinstance.마법력 / 15;
                            용암정령몬스터데미지 = (용암정령HP.몬공격력 + 추가데미지) * 2 - StatManager.Statinstance.방어력 / 3;
                            if (용암정령몬스터데미지 < 1)
                            {
                                용암정령몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 용암정령몬스터데미지;// 몬스터 데미지
                          
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            용암정령몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);
                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 용암정령몬스터데미지;// 몬스터 데미지
                         
                        }
                        Mcool = 2.5f;
                    }//용암정령(치명타확률 증가, 추가데미지 내마법력 15당 1증가.)

                    if (Playbutton.instance.몬스터번호 == 15)
                    {
                        공격확률 = Random.Range(1, 21);
                        if (공격확률 <= 10 && 공격확률 > 0)
                        {
                            추가데미지 = Random.Range(0, 5) + StatManager.Statinstance.공격력 / 6;
                            리프라이언몬스터데미지 = 리프라이언HP.몬공격력 + 추가데미지 - StatManager.Statinstance.방어력 / 3;
                            if (리프라이언몬스터데미지 < 1)
                            {
                                리프라이언몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(1);
                            //text.설명창 = "몬스터의 공격!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 리프라이언몬스터데미지;// 몬스터 데미지
                           
                        }
                        if (공격확률 >= 11 && 공격확률 <= 14)//특수행동
                        {

                            text.설명창 = "몬스터의 하울링!";
                            MonsterShake.ShakeAmount = 0.5f;
                            MonsterShake.ShakeMonster();
                            CamerShake.ShakeCamera();
                            리프라이언HP.instance.MHP += 30 + StatManager.Statinstance.레벨 * 3;
                            if(리프라이언HP.instance.MHP > 리프라이언HP.instance.maxMHP)
                            {
                                리프라이언HP.instance.MHP = 리프라이언HP.instance.maxMHP;
                            }

                        }
                        if (공격확률 >= 15 && 공격확률 <= 19)
                        {
                            추가데미지 = Random.Range(0, 5) + StatManager.Statinstance.공격력 / 6;
                            리프라이언몬스터데미지 = (리프라이언HP.몬공격력 + 추가데미지) - StatManager.Statinstance.방어력 / 3;
                            if (리프라이언몬스터데미지 < 1)
                            {
                                리프라이언몬스터데미지 = 1;
                            }
                            DamageTextManager.instance.몬스터공격Text(2);
                            //text.설명창 = "몬스터의 공격! 치명타!!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 리프라이언몬스터데미지;// 몬스터 데미지
                        
                        }
                        if (공격확률 >= 19 && 공격확률 <= 20)
                        {

                            리프라이언몬스터데미지 = 0;
                            DamageTextManager.instance.몬스터공격Text(3);
                            //text.설명창 = "몬스터의 공격! 회피했다!";
                            animator.SetBool("attack", true);
                            CamerShake.ShakeCamera();
                            StatManager.Statinstance.HP -= 리프라이언몬스터데미지;// 몬스터 데미지
                           
                        }
                        Mcool = 3f;
                    }//리프라이언
                    Mattack = Mcool;


                }


            }
        }
      
            
           
            //Battle1.battle.MonsterTurn = false;
            //Invoke("PlayerTurn",1.0f);
           

        
    }
    void PlayerTurn()
    {
        Battle1.battle.MyTurn = true;
        Battle1.battle.isMyTurn = true;
       
    }
}
