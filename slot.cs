using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{

    public Image icon;
    public Text itemName_Text;
    public Text itemCount_Text;
    public GameObject 장착버튼1;
    public GameObject 장착버튼2;
    public GameObject 장착버튼3;
    public GameObject 장착버튼4;
    public GameObject 장착버튼5;
    public GameObject 장착버튼6;
    public bool is장착버튼 = false;
    public Text Description_Text; // 설명창
    public static int 아이템슬룻번호 = 0;
    public  GameObject 버리기버튼;


    public void Additem(Item _item)
    { 
        itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        if(Item.ItemType.Use == _item.itemType)
        {
            if (_item.itemCount > 0)
            {
                itemCount_Text.text = "x" + _item.itemCount.ToString();
            }
            else
            {
                itemCount_Text.text = "";
            }
            
        }
    }

    public void RemoveItem()
    {
        itemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = null;
    }
   public void 장착버튼활성화()
    {
      
            
            is장착버튼 = true;
             if(gameObject.tag=="슬룻1")
             {
                 Description_Text.text = Inventory.instance.inventoryItemList[0].itemDescription;
                아이템슬룻번호 = 0;
                장착버튼1.SetActive(true);
                장착버튼2.SetActive(false);
                장착버튼3.SetActive(false);
                장착버튼4.SetActive(false);
                장착버튼5.SetActive(false);
                장착버튼6.SetActive(false);
            버리기버튼.SetActive(true);
           
            }
             if (gameObject.tag == "슬룻2")
             {
                 Description_Text.text = Inventory.instance.inventoryItemList[1].itemDescription;
            아이템슬룻번호 = 1;
            장착버튼2.SetActive(true);
                장착버튼1.SetActive(false);
                장착버튼3.SetActive(false);
                장착버튼4.SetActive(false);
                장착버튼5.SetActive(false);
                장착버튼6.SetActive(false);
            버리기버튼.SetActive(true);

        }
             if (gameObject.tag == "슬룻3")
             {
                 Description_Text.text = Inventory.instance.inventoryItemList[2].itemDescription;
            아이템슬룻번호 = 2;
            장착버튼3.SetActive(true);
                장착버튼1.SetActive(false);
                장착버튼2.SetActive(false);
                장착버튼4.SetActive(false);
                장착버튼5.SetActive(false);
                장착버튼6.SetActive(false);
            버리기버튼.SetActive(true);
        }
             if (gameObject.tag == "슬룻4")
             {
                 Description_Text.text = Inventory.instance.inventoryItemList[3].itemDescription;
            아이템슬룻번호 = 3;
            장착버튼4.SetActive(true);
                장착버튼1.SetActive(false);
                장착버튼2.SetActive(false);
                장착버튼3.SetActive(false);
                장착버튼5.SetActive(false);
                장착버튼6.SetActive(false);
            버리기버튼.SetActive(true);
        }
             if (gameObject.tag == "슬룻5")
             {
                 Description_Text.text = Inventory.instance.inventoryItemList[4].itemDescription;
            아이템슬룻번호 = 4;
            장착버튼5.SetActive(true);
                장착버튼1.SetActive(false);
                장착버튼2.SetActive(false);
                장착버튼3.SetActive(false);
                장착버튼4.SetActive(false);
                장착버튼6.SetActive(false);
            버리기버튼.SetActive(true);
        }
             if (gameObject.tag == "슬룻6")
             {
                 Description_Text.text = Inventory.instance.inventoryItemList[5].itemDescription;
            아이템슬룻번호 = 5;
            장착버튼6.SetActive(true);
                장착버튼1.SetActive(false);
                장착버튼2.SetActive(false);
                장착버튼3.SetActive(false);
                장착버튼4.SetActive(false);
                장착버튼5.SetActive(false);
            버리기버튼.SetActive(true);

        }
           

        
     
    }

}
