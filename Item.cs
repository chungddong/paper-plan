using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public Sprite itemIcon;
    public ItemType itemType;

    public enum ItemType
    {
        Use,
        Equip
    }

    public int 추가공격력;
    public int 추가방어력;
    public int 추가체력;

    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType,int _추가공격력 = 0,int _추가방어력 = 0,int 추가체력 = 0, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite;

        추가공격력 = _추가공격력;
        추가방어력 = _추가방어력;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

