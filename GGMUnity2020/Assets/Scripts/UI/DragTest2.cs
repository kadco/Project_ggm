using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragTest2 : MonoBehaviour
{
    public Image m_drag_image;

    void Start()
    {        
    }
    void Update()
    {      
    }

    // Event Trigger 에 추가하기

    public void OnBeginDrag(BaseEventData data)
    {
        print("OnDragBegin");

        //드래그 시작 시, 이미지 오브젝트를 하나 생성한다. 
        //m_drag_image = Resources.Load("Image/flag", typeof(Image)) as Image;

        m_drag_image.transform.SetParent(this.transform.parent);
        m_drag_image.transform.localPosition = this.transform.localPosition;
    }

    public void OnDrag(BaseEventData data)
    {
        //print("OnDrag");
        //생성한 이미지를, 드래그 위치에 맞춰 이동 시킨다. 
        if (m_drag_image != null) { 
            PointerEventData pointer_data = (PointerEventData)data; 
            m_drag_image.transform.position = pointer_data.position; 
        } 
    }

    public void OnEndDrag(BaseEventData data)
    {
        print("OnDragEnd");
        //드랍 했을 때, 생성한 이미지를 없앤다.         
        if (m_drag_image != null) {

            //Destroy(m_drag_image.gameObject); 
            //m_drag_image = null; 
        } 
    }
}

/*
public class EquipSlot : MonoBehaviour, IPointerClickHandler 
{
    public void OnPointerClick(PointerEventData eventData) 
    { 
        //더블 클릭 시 
        if (eventData.clickCount == 2) 
        { 
            if(UserData != null) { if (UserData.m_equip_state) //장착 else //해제 } 
        } 
    } 
}     
*/

