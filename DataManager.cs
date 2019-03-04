using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new Item(10001, "전사의 투구", "방어 +2", Item.ItemType.Equip,0,2));
        itemList.Add(new Item(10101, "전사의 갑옷", "방어 +4", Item.ItemType.Equip,0,4));
        itemList.Add(new Item(10201, "전사의 벨트", "방어 +2", Item.ItemType.Equip,0,2));
        itemList.Add(new Item(10301, "전사의 장검", "공격 +3", Item.ItemType.Equip,3,0));
        itemList.Add(new Item(10401, "전사의 장갑", "방어 +2", Item.ItemType.Equip,0,2));
        itemList.Add(new Item(20001, "체력 물약", "체력 +100", Item.ItemType.Use));
        itemList.Add(new Item(20000, "경험치 물약", "경험치 +2", Item.ItemType.Use));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UseItem(int _itemID)
    {
        switch(_itemID)
        {
            case 20001:
                StatManager.Statinstance.HP += 100;
                break;
            case 20000:
                StatManager.Statinstance.EXP += 2;
                break;
        }
    }
}
