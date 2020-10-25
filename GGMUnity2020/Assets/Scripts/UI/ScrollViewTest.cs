using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewTest : MonoBehaviour
{
    public ScrollViewElement[] element;

    void Start()
    {
        for (int i = 0; i < element.Length; i++)
        {
            ScrollViewItem item = new ScrollViewItem(); 
            item.uid = i; 
            item.name = "item" + i;
            element[i].Setup(item, null);
        }

    }

    void Update()
    {
        
    }
}
