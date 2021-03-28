using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public int id;// 0~500 素材 501~1000 道具 1001~1500 裝備
    public int quantity;//數量
    public ItemInfo itemInfo;
    public Sprite Icon;
    public Item(string n, int ID)
    {
        name = n;
        id = ID;
        SetItemInfo();
    }
    public void UseIt() {
    }
    public void SetItemInfo()
    {
    }
}
