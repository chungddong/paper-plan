using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public static GameManager GameManagerinstance;
    private DataManager theDatabase;
    public int itemID1;
    public int itemID2;
    public int itemID3;
    public int _count1 = 1;
    public int _count2 = 1;
    public int _count3 = 1;
    private List<int> 아이템드랍랜덤;
    private List<Item> TapItemList;
    private Tapslot[] Tapslots;
    public Transform tf;
    public GameObject 적UI;
    public GameObject 드랍아이템;
    public GameObject attackButton;
    public float DropCool = 0f;
    public bool isDie = false;
    public bool istagOpen = false;
    public GameObject 몬스터데미지;
    public GameObject 내데미지;
    public bool isopen = false;

    public GameObject 사망화면;
    public GameObject 인벤토리버튼;
    public GameObject 내UI;
    public GameObject 설명창;
    public GameObject 진행창;
    public GameObject 장비창버튼;

    

    private void Awake()
    {
        Screen.SetResolution(1280, 720, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManagerinstance = this;
        theDatabase = FindObjectOfType<DataManager>();
        Tapslots = tf.GetComponentsInChildren<Tapslot>();
        TapItemList = new List<Item>();
        아이템드랍랜덤 = new List<int>();
    }

    void TapGetAnItem(int _itemID, int _count = 1)
    {
        for (int i = 0; i < theDatabase.itemList.Count; i++)
        {
            if (_itemID == theDatabase.itemList[i].itemID)
            {
                TapItemList.Add(theDatabase.itemList[i]);
                return;
            }
        }
        Debug.LogError("데이터베이스에 해당 ID아이템이 없다.");

    }
    public void TapRemoveSlot()
    {
        for (int i = 0; i < Tapslots.Length; i++)
        {
            Tapslots[i].RemoveItem();
            Tapslots[i].gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
        

        if (Playbutton.instance.is전투 == true)
        {
            if ( MonserList.instance.is몬스터Die == true && isDie == false)
            {
                MonsterDie.instance.is드랍 = true;
                
                Playbutton.instance.진행량++;

                MonserAttackManager.instance.animator.SetBool("Die", true);
                
                Invoke("몬스터사망", 0.5f);
                Playbutton.instance.전투버튼끄기();
                
                DropCool = 2;
                istagOpen = true;
                isDie = true;// 나중에 아이템 선택 할때 다시 false로 바꾸자 현민아
                
               

                if (StatManager.Statinstance.레벨 >0)
                {

                    랜덤추가(10001); 랜덤추가(10101); 랜덤추가(10201); 랜덤추가(10301); 랜덤추가(10401); // 랜덤리스에 아이템추가
                    itemID1 = 아이템드랍랜덤[Random.Range(0, 아이템드랍랜덤.Count)];//드랍아이템창 1번째칸
                    Debug.Log(itemID1);
                    TapGetAnItem(itemID1, _count1);
                    아이템드랍랜덤.Clear();// 랜덤리스트 초기화

                    랜덤추가(20001);
                    itemID2 = 아이템드랍랜덤[Random.Range(0, 아이템드랍랜덤.Count)];//드랍아이템창 2번째칸
                    Debug.Log(itemID2);
                    TapGetAnItem(itemID2, _count2);
                    아이템드랍랜덤.Clear();// 랜덤리스트 초기화

                    랜덤추가(20000);
                    itemID3 = 아이템드랍랜덤[Random.Range(0, 아이템드랍랜덤.Count)];//드랍아이템창 3번째칸
                    Debug.Log(itemID3);
                    TapGetAnItem(itemID3, _count3);
                    아이템드랍랜덤.Clear();// 랜덤리스트 초기화

                    TapRemoveSlot();

                    for (int i = 0; i < TapItemList.Count; i++)
                    {
                        Tapslots[i].gameObject.SetActive(true);
                        Tapslots[i].Additem(TapItemList[i]);
                    }
                    
                }

            }
        }
        if (DropCool > 0)
        {
            DropCool -= Time.deltaTime;
        }
        if (DropCool < 0)
        {
            DropCool = 0;
            if (Inventory.instance.inventoryItemList.Count<6)
            {
                드랍아이템.SetActive(true);
            }
            else
            {
                text.설명창 = "인벤토리 공간이 부족합니다!";
                드랍아이템종료();
                istagOpen = false;
            }
        }
    }
    void 몬스터사망()
    {
        MonserAttackManager.instance.animator.Rebind();
        MonserAttackManager.instance.animator.SetBool("Die", false);
        MonserList.instance.몬스터체력초기화();
        MonserList.instance.is몬스터Die초기화();
        적UI.SetActive(false);
        MonserList.instance.몬스터비활성화();//몬스터 끄기
        몬스터데미지.SetActive(false);
        내데미지.SetActive(false);
        Playbutton.instance.몬스터번호 = 0;
    }
    public void TapslotClick()
    {
        
            Inventory.instance.GetAnItem(itemID1, _count1);
        //Inventory.instance.인벤토리슬룻갯수++;
        //isDie = false;
        드랍아이템종료();
    }
    public void TapslotClick2()
    {
        
            Inventory.instance.GetAnItem(itemID2, _count2);
        //Inventory.instance.인벤토리슬룻갯수++;
        //isDie = false;
        드랍아이템종료();
    }
    public void TapslotClick3()
    {
        
            Inventory.instance.GetAnItem(itemID3, _count3);
        //Inventory.instance.인벤토리슬룻갯수++;
        //isDie = false;
        드랍아이템종료();
    }
    public void Test()
    {
        적UI.SetActive(true);
        attackButton.SetActive(true);
        isDie = false;
        MonsterHpManager.MHPManager.몬스터체력초기화();
        MonsterHpManager.isMDie = false;

    }

    void 랜덤추가(int _itemID)
    {
        아이템드랍랜덤.Add(_itemID);
    }
    
    void 드랍아이템종료()
    {
        TapItemList.Clear();//드랍아이템리스트 초기화
        isDie = false;
        Playbutton.instance.인벤토리버튼.SetActive(true);
        TapRemoveSlot();
        드랍아이템.SetActive(false);
        몬스터데미지.SetActive(true);
        내데미지.SetActive(true);
        istagOpen = false;
        Battle1.battle.MonsterTurn = false;
        Battle1.battle.image.fillAmount = 1;
        Battle1.battle.image2.fillAmount = 1;
        Battle1.battle.버튼활성화();
        Playbutton.instance.is전투 = false;
        Playbutton.instance.행동버튼활성화();
    }

    public void 사망()
    {
        Playbutton.instance.전투버튼끄기();
        Invoke("사망UI제거", 1f);
    }

    void 사망UI제거()
    {
        인벤토리버튼.SetActive(false);
        적UI.SetActive(false);
        설명창.SetActive(false);
        진행창.SetActive(false);
        장비창버튼.SetActive(false);
        Playbutton.instance.행동버튼끄기();
        내UI.SetActive(false);
        Invoke("사망화면활성화", 1f);
    }

   void 사망화면활성화()
    {
        Fade.instance.FadeOut();
        Invoke("fadeIn", 1f);
    }
    void fadeIn()
    {
        사망화면.SetActive(true);
        Fade.instance.FadeIn();
    }
   /* IEnumerator 사망활성화코르틴()
    {
        Fade.instance.FadeOut();
        yield return new WaitForSeconds(1f);

        사망화면.SetActive(true);
        Fade.instance.FadeIn();
    }*/

    public void scene_game()
    {
        SceneManager.LoadScene("Loading");
    }

    
}
