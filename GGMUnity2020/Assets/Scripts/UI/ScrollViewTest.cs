using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewTest : MonoBehaviour
{
    public ScrollViewElement[] element;

    void Start()
    {
        ScrollViewItem item1 = new ScrollViewItem(); item1.uid = 1; item1.name = "1";
        element[0].Setup(item1, null);
        ScrollViewItem item2 = new ScrollViewItem(); item2.uid = 2; item2.name = "2";
        element[1].Setup(item2, null);
        ScrollViewItem item3 = new ScrollViewItem(); item3.uid = 3; item3.name = "3";
        element[2].Setup(item3, null);
        ScrollViewItem item4 = new ScrollViewItem(); item4.uid = 4; item4.name = "4";
        element[3].Setup(item4, null);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
