using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbutton : MonoBehaviour
{
    public static Playbutton instance;
    public GameObject 탐색;
    public GameObject 휴식;
    public GameObject 도망;
    public GameObject 전투;
    public GameObject 이동;
    public GameObject 행동버튼들;
    public GameObject 적UI;
    public GameObject 평타;
    public GameObject 스킬1;
    public GameObject 스킬2;
    public GameObject 스킬3;
    public GameObject 인벤토리버튼;
    public GameObject 일시정지버튼;
    public GameObject 체력바;
    public GameObject 마나바;
    public GameObject 경험치바;
    public GameObject 장비버튼;
    public GameObject 레벨;
    public GameObject 제한턴진행량;
    public GameObject 설명창;
    public GameObject 맵;
    public GameObject 레벨배경;
    public GameObject pause_ui;

    public bool is휴식 = false;

    public GameObject 화산맵;
    public GameObject 숲맵;

    public bool is숲 = true;
    public bool is화산 = false;

    private WaitForSeconds waitTime = new WaitForSeconds(1f);


    public int 제한턴 = 50;
    public int Max진행량 = 30;
    public int 진행량 = 0;

    public bool is전투 = false;
    public int 몬스터번호 = 0;

    float 탐색cool = 0;
    float 탐색애니cool = 0;
    bool is탐색cool = false;
    public bool is탐색 = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(탐색cool>0)
        {
            탐색cool -= Time.deltaTime;
        }
        else
        {
            탐색cool = 0;
        }
        if(탐색cool == 0)
        {
            if(is탐색cool == true)
            {
                is탐색cool = false;
                적UI.SetActive(true);
                전투.SetActive(true);
                도망.SetActive(true);
                if(is숲 == true)
                {
                    몬스터번호 = Random.Range(10, 16);
                    if (진행량 ==  Max진행량)
                    {
                        몬스터번호 = 101;
                    }
                }
                if(is화산 == true)
                {
                    몬스터번호 = 20;
                }
                text.설명창 = "몬스터가 나타났다!";
                MonserList.instance.몬스터활성화();
               
            }
        }

        if(탐색애니cool >0)
        {
            탐색애니cool -= Time.deltaTime;
        }
        else
        {
            탐색애니cool = 0;
        }
        if(탐색애니cool ==0)
        {
            if(is숲 == true)
            {
                Background.instance.animator.SetBool("Start", false);
            }
           if(is화산 == true)
            {
                BackGround2.instance.animator.SetBool("Start", false);
            }
        }
    }
    public void 탐색Click()
    {
        탐색cool = 2.5f;
        탐색애니cool = 1.5f;
        text.설명창 = "탐색중...";
        if (is숲 == true)
        {
            Background.instance.animator.SetBool("Start", true);
        }
        if (is화산 == true)
        {
            BackGround2.instance.animator.SetBool("Start", true);
        }
        휴식.SetActive(false);
        탐색.SetActive(false);
        이동.SetActive(false);
        is탐색cool = true;
        is탐색 = true;
        제한턴 -= 1;
    }

    public void 전투Click()
    {
        is전투 = true;
        is탐색 = false;
        전투.SetActive(false);
        도망.SetActive(false);
        인벤토리버튼.SetActive(false);// 나중에 죽엇을시 만들때 이거 true로하자 현민아
        text.설명창 = "전투시작!";
        Invoke("전투실행", 0.5f);
        Battle1.battle.MyTurn = true;
    }
    void 전투실행()
    {
       
        평타.SetActive(true);
        스킬1.SetActive(true);
        스킬2.SetActive(true);
        스킬3.SetActive(true);
    }

    public void 도망Click()
    {
        제한턴 -= 1;
      
        전투.SetActive(false);
        도망.SetActive(false);
        Invoke("도망실행", 1f);
    }
    void 도망실행()
    {
        text.설명창 = "성공적으로 도망쳤다!";
        is탐색 = false;
        적UI.SetActive(false);
        MonserList.instance.몬스터비활성화();//몬스터 끄기
        몬스터번호 = 0;
        탐색.SetActive(true);
        휴식.SetActive(true);
        이동.SetActive(true);
    }

    public void 휴식Click()
    {
        is휴식 = true;
        Invoke("휴식실행", 2.0f);
        text.설명창 = "휴식중....";
        행동버튼끄기();
    }
    void 휴식실행()
    {
        제한턴 -= 2;
        StatManager.Statinstance.HP += 40;
        text.설명창 = "2턴간 휴식하셨습니다.";
        행동버튼활성화();
        is휴식 = false;
    }

    public void 이동Click()
    {
        맵.SetActive(true);
        모든UI끄기();
        전투버튼끄기();
        행동버튼끄기();
        
    }

    public void 맵나가기()
    {
        맵.SetActive(false);
        모든UI키기();
        행동버튼활성화();
    }

    public void 전투버튼끄기()
    {
        평타.SetActive(false);
        스킬1.SetActive(false);
        스킬2.SetActive(false);
        스킬3.SetActive(false);
    }

    public void 행동버튼활성화()
    {
        if (is탐색 == false)
        {
            탐색.SetActive(true);
            휴식.SetActive(true);
            이동.SetActive(true);
        }
        else
        {
            전투.SetActive(true);
            도망.SetActive(true);
        }
    
    }

    public void 행동버튼끄기()
    {
        전투.SetActive(false);
        도망.SetActive(false);
        탐색.SetActive(false);
        휴식.SetActive(false);
        이동.SetActive(false);
    }
    public void 설명창끄기()
    {
        설명창.SetActive(false);
    }
    public void 설명창키기()
    {
        설명창.SetActive(true);
    }
    public void 모든UI끄기()
    {
        레벨.SetActive(false);
        설명창.SetActive(false);
        제한턴진행량.SetActive(false);
        체력바.SetActive(false);
        마나바.SetActive(false);
        경험치바.SetActive(false);
        인벤토리버튼.SetActive(false);
        장비버튼.SetActive(false);
        레벨배경.SetActive(false);
        일시정지버튼.SetActive(false);

    }
    public void 모든UI키기()
    {
        레벨.SetActive(true);
        설명창.SetActive(true);
        제한턴진행량.SetActive(true);
        체력바.SetActive(true);
        마나바.SetActive(true);
        경험치바.SetActive(true);
        인벤토리버튼.SetActive(true);
        장비버튼.SetActive(true);
        레벨배경.SetActive(true);
        일시정지버튼.SetActive(true);
    }
    
    public void 이동_test()
    {
        SceneManager.LoadScene("Main");
    }

    public void 화산버튼()
    {
        if (is화산 == false)
        {
            제한턴 -= 1;
            Fade.instance.FadeOut();
            Invoke("화산fadeIn", 1f);
        }
    }
    void 화산fadeIn()
    {
        숲맵.SetActive(false);
        화산맵.SetActive(true);
        is맵초기화();
        is화산 = true;
        맵나가기();
        text.설명창 = "화산지역으로 이동하였다. ";
        Fade.instance.FadeIn();
    }

   /* IEnumerator 화산이동코르틴()
    {
        Fade.instance.FadeOut();
        yield return waitTime;
        숲맵.SetActive(false);
        화산맵.SetActive(true);
        is맵초기화();
        is화산 = true;
        맵나가기();
        text.설명창 = "화산지역으로 이동하였다. ";
        Fade.instance.FadeIn();
    }*/

    public void 숲버튼()
    {
        if (is숲 == false)
        {
            제한턴 -= 1;
            Fade.instance.FadeOut();
            Invoke("숲fadeIn", 1f);
        }
    }

    void 숲fadeIn()
    {
        숲맵.SetActive(true);
        화산맵.SetActive(false);
        is맵초기화();
        is숲 = true;
        맵나가기();
        text.설명창 = "숲지역으로 이동하였다. ";
        Fade.instance.FadeIn();
    }
    /*IEnumerator 숲이동코르틴()
    {
        Fade.instance.FadeOut();
        yield return waitTime;
        숲맵.SetActive(true);
        화산맵.SetActive(false);
        is맵초기화();
        is숲 = true;
        맵나가기();
        text.설명창 = "숲지역으로 이동하였다. ";
        Fade.instance.FadeIn();
    }*/

    void is맵초기화()
    {
        is숲 = false;
        is화산 = false;

    }

    public void 일시정지()
    {
        Time.timeScale = 0f;
        모든UI끄기();
        pause_ui.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        모든UI키기();
        pause_ui.SetActive(false);
    }

    public void 나가기()
    {
        SceneManager.LoadScene("Main");
    }
}
