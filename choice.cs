using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choice : MonoBehaviour
{
    public GameObject 내UI;
    public static choice instance;
    public GameObject 스텟창;
    public GameObject 스킬창;
    public GameObject 스킬선택1;
    public GameObject 스킬선택2;
    public GameObject 설명창이미지;
    public Sprite 스킬1선택1이미지;
    public Sprite 스킬1선택2이미지;
    public Text 스킬선택1이름;
    public Text 스킬선택2이름;
    public Text 설명창스킬이름;
    public Text 설명창스킬설명;
    public GameObject 스킬설명;
    public GameObject 스킬이름;
    public GameObject 스킬설명창아이콘;
    public string 스킬설명1;
    public string 스킬설명2;
    public GameObject 인벤토리버튼;
    public GameObject 장비버튼;
    public GameObject 습득버튼;
    
    public GameObject 스킬1;
    public GameObject 스킬1버튼;
    public GameObject 스킬2;
    public GameObject 스킬2버튼;
    public GameObject 스킬3;
    public GameObject 스킬3버튼;
    public bool isOpen;
    public bool isSkillOpen;
    int is스킬선택;
    public int 현재스킬번호;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        스킬1.SetActive(false);
        스킬2.SetActive(false);
        스킬3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void 스킬선택(int 스킬번호)
    {

        isSkillOpen = true;
        Playbutton.instance.행동버튼끄기();
        스킬창.SetActive(true);
        인벤토리버튼.SetActive(false);
        장비버튼.SetActive(false);
        내UI.SetActive(false);
        
        text.설명창 = "스킬을 선택하세요!";
        if (스킬번호 ==1)
        {
            if(StatManager.Statinstance.캐릭터ID ==1)
            {
                스킬1선택1이미지 = Resources.Load("스킬아이콘/" + 111.ToString(), typeof(Sprite)) as Sprite;
                스킬1선택2이미지 = Resources.Load("스킬아이콘/" + 112.ToString(), typeof(Sprite)) as Sprite;
                스킬선택1.GetComponent<Image>().sprite = 스킬1선택1이미지;
                스킬선택2.GetComponent<Image>().sprite = 스킬1선택2이미지;
                스킬선택1이름.text = "스노우볼";
                스킬설명1 = "소모기력 : 2 \n 쿨타임 : 3초 \n 10 + 마법력50% 데미지를 줍니다. \n 강화 : 다음 다른 공격스킬은 1.2배의 데미지를 줍니다.";
                스킬선택2이름.text = "아이스볼트";
                스킬설명2 = "소모기력 : 5 \n 쿨타임 : 7초 \n 15 + 마법력60% 데미지를 줍니다. \n 강화 : 이 스킬이 '35 + 마법력80%데미지를 줍니다.' 로 변경됩니다.";
            }
            현재스킬번호 = 1;
        }
        if (스킬번호 == 2)
        {
            if (StatManager.Statinstance.캐릭터ID == 1)
            {
                스킬1선택1이미지 = Resources.Load("스킬아이콘/" + 121.ToString(), typeof(Sprite)) as Sprite;
                스킬1선택2이미지 = Resources.Load("스킬아이콘/" + 122.ToString(), typeof(Sprite)) as Sprite;
                스킬선택1.GetComponent<Image>().sprite = 스킬1선택1이미지;
                스킬선택2.GetComponent<Image>().sprite = 스킬1선택2이미지;
                스킬선택1이름.text = "얼음방패";
                스킬설명1 = "소모기력 : 5 \n 쿨타임 : 5초 \n 3초동안 방어력이 마법력만큼 증가합니다.";
                스킬선택2이름.text = "눈보라";
                스킬설명2 = "소모기력 : 6 \n 쿨타임 : 8초 \n 10 + 마법력50% 데미지를 줍니다. \n 3초간 눈보라를 일으켜, 그 사이에 공격하는 기본공격은 마법력20% 추가데미지를 줍니다.";
            }
            현재스킬번호 = 2;
        }
        if (스킬번호 == 3)
        {
            if (StatManager.Statinstance.캐릭터ID == 1)
            {
                스킬1선택1이미지 = Resources.Load("스킬아이콘/" + 131.ToString(), typeof(Sprite)) as Sprite;
                스킬1선택2이미지 = Resources.Load("스킬아이콘/" + 132.ToString(), typeof(Sprite)) as Sprite;
                스킬선택1.GetComponent<Image>().sprite = 스킬1선택1이미지;
                스킬선택2.GetComponent<Image>().sprite = 스킬1선택2이미지;
                스킬선택1이름.text = "블리자드샤워";
                스킬설명1 = "소모기력 : 10 \n 쿨타임 : 20초 \n마법력800% 데미지를 줍니다.";
                스킬선택2이름.text = "바인딩";
                스킬설명2 = "소모기력 : 5 \n 쿨타임 : 60초 \n 적이 6초동안 기절합니다.";
            }
            현재스킬번호 = 3;
        }

    }

    public void 스킬선택버튼1()
    {
        설명창이미지.GetComponent<Image>().sprite = 스킬1선택1이미지;
        설명창스킬이름.text = 스킬선택1이름.text;
       설명창스킬설명.text = 스킬설명1;
        습득버튼.SetActive(true);
        스킬이름.SetActive(true);
        스킬설명.SetActive(true);
        스킬설명창아이콘.SetActive(true);
        is스킬선택 = 1;
    }
    public void 스킬선택버튼2()
    {
        설명창이미지.GetComponent<Image>().sprite = 스킬1선택2이미지;
        설명창스킬이름.text = 스킬선택2이름.text;
        설명창스킬설명.text = 스킬설명2;
        습득버튼.SetActive(true);
        스킬이름.SetActive(true);
        스킬설명.SetActive(true);
        스킬설명창아이콘.SetActive(true);
        is스킬선택 = 2;
    }

    public void 습득()
    {
        if (현재스킬번호 ==1)
        {
            if(is스킬선택 ==1)
            {
               // Playbutton.instance.스킬1.SetActive(true);
                스킬1.GetComponent<SpriteRenderer>().sprite = 스킬1선택1이미지;
                스킬1버튼.GetComponent<Image>().sprite = 스킬1선택1이미지;
                // Playbutton.instance.스킬1.SetActive(false);
                Battle1.battle.스킬활성화(1, 1);
            }
            if (is스킬선택 == 2)
            {
                //Playbutton.instance.스킬1.SetActive(true);
                스킬1.GetComponent<SpriteRenderer>().sprite = 스킬1선택2이미지;
                스킬1버튼.GetComponent<Image>().sprite = 스킬1선택2이미지;
                // Playbutton.instance.스킬1.SetActive(false);
                Battle1.battle.스킬활성화(1, 2);
            }
            스킬1.SetActive(true);
        }
        if (현재스킬번호 == 2)
        {
            if (is스킬선택 == 1)
            {
                // Playbutton.instance.스킬1.SetActive(true);
                스킬2.GetComponent<SpriteRenderer>().sprite = 스킬1선택1이미지;
                스킬2버튼.GetComponent<Image>().sprite = 스킬1선택1이미지;
                // Playbutton.instance.스킬1.SetActive(false);
                Battle1.battle.스킬활성화(2, 1);
            }
            if (is스킬선택 == 2)
            {
                //Playbutton.instance.스킬1.SetActive(true);
                스킬2.GetComponent<SpriteRenderer>().sprite = 스킬1선택2이미지;
                스킬2버튼.GetComponent<Image>().sprite = 스킬1선택2이미지;
                // Playbutton.instance.스킬1.SetActive(false);
                Battle1.battle.스킬활성화(2, 2);
            }
            스킬2.SetActive(true);
        }
        if (현재스킬번호 == 3)
        {
            if (is스킬선택 == 1)
            {
                // Playbutton.instance.스킬1.SetActive(true);
                스킬3.GetComponent<SpriteRenderer>().sprite = 스킬1선택1이미지;
                스킬3버튼.GetComponent<Image>().sprite = 스킬1선택1이미지;
                // Playbutton.instance.스킬1.SetActive(false);
                Battle1.battle.얼법강화 = true;
                Battle1.battle.스킬활성화(3, 1);
            }
            if (is스킬선택 == 2)
            {
                //Playbutton.instance.스킬1.SetActive(true);
                스킬3.GetComponent<SpriteRenderer>().sprite = 스킬1선택2이미지;
                스킬3버튼.GetComponent<Image>().sprite = 스킬1선택2이미지;
                // Playbutton.instance.스킬1.SetActive(false);
                Battle1.battle.얼법강화 = true;
                Battle1.battle.스킬활성화(3, 2);
            }
            스킬3.SetActive(true);
        }
        Playbutton.instance.행동버튼활성화();
        스킬창.SetActive(false);
        인벤토리버튼.SetActive(true);
        장비버튼.SetActive(true);
        스킬이름.SetActive(false);
        스킬설명.SetActive(false);
        스킬설명창아이콘.SetActive(false);
        isSkillOpen = false;
        내UI.SetActive(true);
    }
        

    public void 스텟선택()
    {
        isOpen = true;
        //StatManager.Statinstance.is레벨업 = false;
        Invoke("스텟창열기", 0.5f);
        인벤토리버튼.SetActive(false);
        장비버튼.SetActive(false);
        Playbutton.instance.행동버튼끄기();
        text.설명창 = "레벨업! 스텟을 선택하세요!";
    }
    void 스텟창열기()
    {
        스텟창.SetActive(true);
    }

    public void 공격력선택()
    {
        StatManager.Statinstance.공격력 += 2;
        스텟창종료();
    }

    public void 체력선택()
    {
        StatManager.Statinstance.maxHP += 10;
        스텟창종료();
    }

    public void 마법력선택()
    {
        StatManager.Statinstance.마법력 += 5;
        스텟창종료();
    }

    public void 방어력선택()
    {
        StatManager.Statinstance.방어력 += 2;
        스텟창종료();
    }

    public void 기력선택()
    {
        StatManager.Statinstance.max기력 += 1;
        스텟창종료();
    }

    public void 스텟창종료()
    {
        Playbutton.instance.행동버튼활성화();
        스텟창.SetActive(false);
        인벤토리버튼.SetActive(true);
        장비버튼.SetActive(true);
        isOpen = false;

    }

}
