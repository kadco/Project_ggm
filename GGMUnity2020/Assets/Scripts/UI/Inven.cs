using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven : MonoBehaviour
{
    List<Item> ItemList;    //보유아이템
    List<Item> InvenList;   //인벤토리에 보여주는 아이템

    public GameObject[] InvenObject;  //8

    void Start()
    {
        ItemList = new List<Item>();

        InvenList = new List<Item>();

        //ItemList에 아이템 추가 ---------------------

        //ItemList.Add(new Item(0, "spritename", 0)); // Resources/icons/
        ItemList.Add(new Weapon(1, "icons/sword"));  
        ItemList.Add(new Weapon(2, "icons/sword"));
        ItemList.Add(new Armor(3, "icons/armor"));
        ItemList.Add(new Armor(4, "icons/armor"));
        ItemList.Add(new Ring(5, "icons/rings"));

        //InvenList에 아이템 추가 -------------------
        foreach (Item item in ItemList)
            InvenList.Add(item);

        //실제 인벤 디스플레이 하기 ------------------        
        Display(0);  
    }

    void Display(int _sortType = 0)
    {    

        for (int i = 0; i < InvenObject.Length; i++)
        {
            InvenItem iobj = InvenObject[i].GetComponent<InvenItem>();
            iobj.text.text = "";
            iobj.frame.sprite = Resources.Load<Sprite>("icons/f") as Sprite;
            iobj.image.sprite = Resources.Load<Sprite>("icons/f") as Sprite;
            if (i >= InvenList.Count) continue;
            
            Item item = InvenList[i];
            if (_sortType == 1 && item.type != 1) continue; //무기만 보여줌

            iobj.text.text = "" + item.index;
            iobj.image.sprite = Resources.Load<Sprite>(item.imagename) as Sprite;            
            //item.Method();     
        }
    }

    public void ToggleValueChanged(Toggle change)
    {
        print(change.name + " " + change.isOn);

        if (change.name == "Toggle1" && change.isOn) Display(0);
        if (change.name == "Toggle2" && change.isOn) Display(1);
    }
}

//-----------------------------------------------------------------------
public enum ItemType { Weapon = 1, Armor = 2, Ring = 3 }

public class Item
{
    public int index;
    public int type;
    public string imagename;

    public Item(int _index, string _name, int _type = 0)
    {
        index = _index;
        type = _type;
        imagename = _name;
    }
    public virtual void Method() { Debug.Log("Item"); }
}

class Weapon : Item  
{
    public Weapon(int _index, string _name) : base(_index, _name, 1) //ItemType
    {
    }
    public override void Method() { Debug.Log("weapon"); }
}
class Armor : Item 
{
    public Armor(int _index, string _name) : base(_index, _name, 2)
    {
    }
    public override void Method() { Debug.Log("armor"); }
}
class Ring : Item
{
    public Ring(int _index, string _name) : base(_index, _name, 3)
    {
    }
    public override void Method() { Debug.Log("ring"); }
}

//InvenList.Sort((x, y) => x.index.CompareTo(y.index) );
