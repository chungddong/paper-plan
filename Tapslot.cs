using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tapslot : MonoBehaviour
{
    public Image icon;
    public Text itemName_Text;
    public Text itemCount_Text;
    public Text 설명;


    public void Additem(Item _Titem)
    {
        itemName_Text.text = _Titem.itemName;
        icon.sprite = _Titem.itemIcon;
        설명.text = _Titem.itemDescription;

        /*if (Item.ItemType.Use == _Titem.itemType)
        {
            if (_Titem.itemCount > 0)
            {
                //itemCount_Text.text = "x" + _Titem.itemCount.ToString();
            }
            else
            {
                itemCount_Text.text = "";
            }

        }*/
    }

    public void RemoveItem()
    {
        itemName_Text.text = "";
        itemCount_Text.text = "";
        설명.text = "";
        icon.sprite = null;
    }
}
