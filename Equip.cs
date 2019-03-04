using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Equip : MonoBehaviour
{
    public static Equip instance;
    public GameObject 내HPbar;
    public GameObject 내MPbar;
    public GameObject 내레벨;
    public GameObject 레벨배경;

    public GameObject 장비창;
    private const int 머리 = 0, 몸 = 1, 허리 = 2, 무기 = 3, 손 = 4;
    public GameObject 머리Text;
    public GameObject 몸Text;
    public GameObject 허리Text;
    public GameObject 무기Text;
    public GameObject 손Text;
    public GameObject 인벤토리버튼;

    public Text 공격력Text;
    public Text 방어력Text;
    public Text 마법력Text;
    public Text 레벨Text;
    public Text 설명Text;
    public Text 아이템이름Text;

    public Image[] img_slots;
    public Item[] equipItemList;

    public bool isopen = false;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        설명Text.text = "";
        아이템이름Text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isopen == true)
        {
            if (img_slots[0].sprite == null)
            {
                머리Text.SetActive(true);
            }
            else if(img_slots[0].sprite != null)
            {
                머리Text.SetActive(false);
            }

            if (img_slots[1].sprite == null)
            {
                몸Text.SetActive(true);
            }
            else if (img_slots[1].sprite != null)
            {
                몸Text.SetActive(false);
            }

            if (img_slots[2].sprite == null)
            {
                허리Text.SetActive(true);
            }
            else if (img_slots[2].sprite != null)
            {
                허리Text.SetActive(false);
            }

            if (img_slots[3].sprite == null)
            {
                무기Text.SetActive(true);
            }
            else if (img_slots[3].sprite != null)
            {
                무기Text.SetActive(false);
            }

            if (img_slots[4].sprite == null)
            {
                손Text.SetActive(true);
            }
            else if (img_slots[4].sprite != null)
            {
                손Text.SetActive(false);
            }
        }
    }

    public void EquipEffect(Item _item)
    {
        StatManager.Statinstance.maxHP += _item.추가체력;
        StatManager.Statinstance.공격력 += _item.추가공격력;
        StatManager.Statinstance.방어력 += _item.추가방어력;
    }
    public void TakeOffEffect(Item _item)
    {
        StatManager.Statinstance.maxHP -= _item.추가체력;
        StatManager.Statinstance.공격력 -= _item.추가공격력;
        StatManager.Statinstance.방어력 -= _item.추가방어력;
    }

    public void ClearEquip()
    {
        Color color = img_slots[0].color;
        color.a = 0f;

        for (int i = 0;  i < img_slots.Length; i++)
        {
            img_slots[i].sprite = null;
            img_slots[i].color = color;
        }
    }

    public void ShowEquip()
    {
        Color color = img_slots[0].color;
        color.a = 1f;
        for (int i = 0; i < img_slots.Length; i++)
        {
            if(equipItemList[i].itemID !=0)
            {
                img_slots[i].sprite = equipItemList[i].itemIcon;
                img_slots[i].color = color;
            }
        }
     }


    public void EquipItem(Item _item)
    {
        string temp = _item.itemID.ToString();
        temp = temp.Substring(0,3);
        switch (temp)
        {
            case "100": // 머리
                EquipItemCheck(머리, _item);
                break;
            case "101": // 몸
                EquipItemCheck(몸, _item);
                break;
            case "102": // 허리
                EquipItemCheck(허리, _item);
                break;
            case "103": // 무기
                EquipItemCheck(무기, _item);
                break;
            case "104": // 손
                EquipItemCheck(손, _item);
                break;
        }
    }

    public void EquipItemCheck(int _count, Item _item)
    {
        if(equipItemList[_count].itemID == 0)
        {
            equipItemList[_count] = _item;
        }
        else
        {
            Inventory.instance.EuipToInventory(equipItemList[_count]);
            TakeOffEffect(equipItemList[_count]);
            equipItemList[_count] = _item;
        }
        EquipEffect(_item);
    }

    public void EquipClick()
    {if (Inventory.instance.isopen == false && GameManager.GameManagerinstance.istagOpen == false && Playbutton.instance.is전투 == false && Playbutton.instance.is탐색 == false && Playbutton.instance.is휴식 == false)
        {
            isopen = true;
            인벤토리버튼.SetActive(false);
            Playbutton.instance.설명창끄기();
            장비창.SetActive(true);
            내HPbar.SetActive(false);
            내MPbar.SetActive(false);
            내레벨.SetActive(false);
            레벨배경.SetActive(false);
            ClearEquip();
            ShowEquip();
            Playbutton.instance.행동버튼끄기();
            공격력Text.text = "공격력 : " + StatManager.Statinstance.공격력;
            마법력Text.text = "마법력 : " + StatManager.Statinstance.마법력;
            방어력Text.text = "방어력 : " + StatManager.Statinstance.방어력;
            레벨Text.text = "LV : " + StatManager.Statinstance.레벨 ;
        }
    }
    public void EQuipClose()
    {
        isopen = false;
        Playbutton.instance.설명창키기();
        인벤토리버튼.SetActive(true);
        장비창.SetActive(false);
        내HPbar.SetActive(true);
        내MPbar.SetActive(true);
        내레벨.SetActive(true);
        레벨배경.SetActive(true);
        아이템이름Text.text = "";
        설명Text.text = "";
        ClearEquip();
        Playbutton.instance.행동버튼활성화();
    }

    public void EquipSlotClick(GameObject 장비슬룻)
    {
        if(장비슬룻.tag == "슬룻1")
        {
            아이템이름Text.text = equipItemList[0].itemName;
            설명Text.text = equipItemList[0].itemDescription;
        }
        if (장비슬룻.tag == "슬룻2")
        {
            아이템이름Text.text = equipItemList[1].itemName;
            설명Text.text = equipItemList[1].itemDescription;
        }
        if (장비슬룻.tag == "슬룻3")
        {
            아이템이름Text.text = equipItemList[2].itemName;
            설명Text.text = equipItemList[2].itemDescription;
        }
        if (장비슬룻.tag == "슬룻4")
        {
            아이템이름Text.text = equipItemList[3].itemName;
            설명Text.text = equipItemList[3].itemDescription;
        }
        if (장비슬룻.tag == "슬룻5")
        {
            아이템이름Text.text = equipItemList[4].itemName;
            설명Text.text = equipItemList[4].itemDescription;
        }
    }
}
