using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewElement : MonoBehaviour
{
    public long m_uid;
    public Text m_text;
    public Image m_image;
    public Button m_button;

    private ScrollViewItem item;
    private ScrollViewList scrollList;

    void Start()
    {
        if(m_button != null) m_button.onClick.AddListener(onClick_button);
    }

    public void Setup(ScrollViewItem currentItem, ScrollViewList currentScrollList)
    {
        item = currentItem;
        scrollList = currentScrollList;

        m_uid = item.uid;
        m_text.text = item.name;
    }
     
    public void onClick_button()
    {
        print("click " + m_uid);
        //scrollList.OnEventCallback(item.uid, "");
    }
}



//CGame.Instance.IconImage_set(icon_image, item.shop_index);
//TableInfo_shop table = CGameTable.Instance.Get_TableInfo_shop(item.shop_index);
//m_image.sprite = Resources.Load<Sprite>(table.icon) as Sprite;