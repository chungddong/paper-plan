using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Equip theEquip;
    public bool isopen = false;

    public static Inventory instance;
    public int 인벤토리슬룻갯수 = 0;
    private DataManager theDatabase;
    private slot[] slots;// 인벤토리 슬룻
    public List<Item> inventoryItemList; // 플레이어가 소지한 아이템 리스트

    
    public string[] Des;

    public Transform tf;//슬룻 부모객체

    public GameObject go;// 인벤토리 활성화 비활성화
    public GameObject 내데미지;
    public GameObject 몬스터데미지;
    public Text Description_Text; // 설명창

    private int selectedItem; //선택된 아이템
    private bool activated; // 인벤토리 활성화시 true
   
    private bool isinventorybuttonClick = false;

    public GameObject attackButton;
    public GameObject 내UI;
    public GameObject 적UI;
    public GameObject 장착버튼;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    public GameObject 장착버튼1;
    public GameObject 장착버튼2;
    public GameObject 장착버튼3;
    public GameObject 장착버튼4;
    public GameObject 장착버튼5;
    public GameObject 장착버튼6;

    public GameObject 버리기버튼;

    void Start()
    {
        instance = this;
        theDatabase = FindObjectOfType<DataManager>();
        inventoryItemList = new List<Item>();
        slots = tf.GetComponentsInChildren<slot>();
        //inventoryItemList.Add(new Item(101, "전사의 투구", "방어 +2", Item.ItemType.Equip));
        //inventoryItemList.Add(new Item(102, "전사의 갑옷", "방어 +4", Item.ItemType.Equip));
        theEquip = FindObjectOfType<Equip>();
    }

    public void EuipToInventory(Item _item)
    {
        inventoryItemList.Add(_item);
    }

    public void inventoryButtonClick()
    {
        if(Equip.instance.isopen == false)
        {
            isinventorybuttonClick = true;
        }
        
    }

    void OpenInventory()
    {
        if (Equip.instance.isopen == false && Playbutton.instance.is전투 == false && Playbutton.instance.is탐색 == false && Playbutton.instance.is휴식 == false)
        {
            

            ShowInventory();
            RemoveSlot();
            Description_Text.text = "";
            isopen = true;

            for (int i = 0; i < inventoryItemList.Count; i++)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].Additem(inventoryItemList[i]);
            }
        }
    }
    public void CloseInventory()
    {
        if (isopen == true)
        {


            go.SetActive(false);
            내UI.SetActive(true);
            적UI.SetActive(true);
            isinventorybuttonClick = false;
            activated = false;
            내데미지.SetActive(true);
            몬스터데미지.SetActive(true);
            장착버튼1.SetActive(false);
            장착버튼2.SetActive(false);
            장착버튼3.SetActive(false);
            장착버튼4.SetActive(false);
            장착버튼5.SetActive(false);
            장착버튼6.SetActive(false);
            버리기버튼.SetActive(false);
            Playbutton.instance.행동버튼활성화();
            Playbutton.instance.설명창키기();
            isopen = false;
        }
    }
 
    void ShowInventory()
    {
        go.SetActive(true);
        내데미지.SetActive(false);
        몬스터데미지.SetActive(false);
        attackButton.SetActive(false);
        내UI.SetActive(false);
        적UI.SetActive(false);
        Playbutton.instance.행동버튼끄기();
        Playbutton.instance.설명창끄기();

    }
    public void RemoveSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isinventorybuttonClick)
        {
            if (GameManager.GameManagerinstance.istagOpen == false)
            {
                activated = !activated;
                if (activated)
                {

                    OpenInventory();
                    isinventorybuttonClick = false;
                }
                else
                {
                    CloseInventory();

                }
            }
        }
    }
    public void GetAnItem(int _itemID, int _count = 1)
    {
        for(int i = 0; i <theDatabase.itemList.Count; i++)// 데이터 베이스에 아이템 검색
        {
            if(_itemID == theDatabase.itemList[i].itemID)//데이터 베이스에 아이템 발견
            {
                for(int j = 0; j< inventoryItemList.Count; j++)// 소지품에 같은 아이템이 있는지 검색
                {
                    if(inventoryItemList[j].itemID == _itemID)// 소지에 같은 아이템이 있다 -> 갯수만 증가시킨다.
                    {
                        if(inventoryItemList[j].itemType == Item.ItemType.Use)
                        {
                       
                            inventoryItemList[j].itemCount += _count;
                            
                        }
                        else
                        {
                            if (inventoryItemList.Count < 6)
                            {
                                inventoryItemList.Add(theDatabase.itemList[i]);
                                //Inventory.instance.인벤토리슬룻갯수++;
                            }
                            else
                            {
                                Debug.LogError("가방공간 부족");
                            }

                        }
                        return;
                    }
                }
                if (inventoryItemList.Count <6)
                {


                    inventoryItemList.Add(theDatabase.itemList[i]);// 소지품에 같은 아이템이 없다 -> 소지품에 해당 아이템 추가
                    //Inventory.instance.인벤토리슬룻갯수++;
                    inventoryItemList[inventoryItemList.Count - 1].itemCount = _count;
                }
                else
                {
                    Debug.LogError("가방공간 부족");
                }
                return;
            }
        }
        Debug.LogError("데이터베이스에 해당 ID아이템이 없다.");
    }

    public void UseButtonClick()
    {
        for(int i = 0; i<inventoryItemList.Count; i++)
        {
            if(inventoryItemList[slot.아이템슬룻번호].itemID == inventoryItemList[i].itemID)
            {
                if(inventoryItemList[slot.아이템슬룻번호].itemType == Item.ItemType.Use)//아이템이 소모품이라면
                {
                    theDatabase.UseItem(inventoryItemList[slot.아이템슬룻번호].itemID);
                    if (inventoryItemList[slot.아이템슬룻번호].itemCount > 1)
                    {
                        inventoryItemList[slot.아이템슬룻번호].itemCount--;
                        버리기버튼.SetActive(false);
                        장착버튼끄기();
                        Debug.Log("아이템사용");
                    }
                    else
                    {
                        inventoryItemList.RemoveAt(slot.아이템슬룻번호);
                        버리기버튼.SetActive(false);
                        장착버튼끄기();
                        //Inventory.instance.인벤토리슬룻갯수--;
                        Debug.Log("아이템사용");
                    }
                    OpenInventory();
                    break;
                }
                else if(inventoryItemList[slot.아이템슬룻번호].itemType == Item.ItemType.Equip)// 아이템이 장비템이라면
                {
                    theEquip.EquipItem(inventoryItemList[i]);
                    inventoryItemList.RemoveAt(i);
                    버리기버튼.SetActive(false);
                    장착버튼끄기();
                    OpenInventory();
                    break;
                }

               
            }
        }
    }
    public void 버리기클릭()
    {
        inventoryItemList.RemoveAt(slot.아이템슬룻번호);
        //instance.인벤토리슬룻갯수--;
        Debug.Log("아이템사용");
        버리기버튼.SetActive(false);
        장착버튼끄기();
        OpenInventory();
    }

    void 장착버튼끄기()
    {
        장착버튼1.SetActive(false);
        장착버튼2.SetActive(false);
        장착버튼3.SetActive(false);
        장착버튼4.SetActive(false);
        장착버튼5.SetActive(false);
        장착버튼6.SetActive(false);
    }
}
