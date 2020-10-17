using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image m_drag_image;
    Transform _startParent;

    void Start()
    {        
    }
    void Update()
    {      
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startParent = transform.parent;
        transform.SetParent(GameObject.Find("Canvas").transform); //위치.
        transform.SetAsLastSibling();  //UI sort 순서.
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_startParent);  //위치.                                           
        //transform.localPosition = Vector3.zero;
        GetComponent<Image>().raycastTarget = true;
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        print("Drop " + gameObject.name);        
    }
}
/*
public void OnDrag(PointerEventData eventData)
{
    transform.position = eventData.position;
}

public void OnBeginDrag(PointerEventData eventData)
{
    _itemBeingDragged = gameObject.GetComponentInParent().GetItem();
    _startParent = transform.parent;
    transform.SetParent(GameObject.FindGameObjectWithTag("UI Canvas").transform);
    GetComponent().raycastTarget = false;
}

public void OnEndDrag(PointerEventData eventData)
{
    transform.SetParent(_startParent);
    transform.localPosition = Vector3.zero;
    _itemBeingDragged = null;
    GetComponent().raycastTarget = true;
}

public Image _icon;
public void OnDrop(PointerEventData eventData)
{
    var item = ItemDragHandler._itemBeingDragged;
    if (item != null)
    {
        _icon.sprite = item.icon;
        _icon.enabled = true;
    }
}
*/

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


/*
  
    // Event Trigger

    public void OnBeginDrag(BaseEventData data)
    {
        print("OnDragBegin");
        ////드래그 시작 시, 이미지 오브젝트를 하나 생성한다. 
        m_drag_image = Resources.Load("Image/flag", typeof(Image)) as Image;
        m_drag_image.transform.SetParent(this.transform.parent); 
        m_drag_image.transform.localPosition = this.transform.localPosition;
    }     

    public void OnDrag(BaseEventData data) 
    {
        //print("OnDrag");
        ////생성한 이미지를, 드래그 위치에 맞춰 이동 시킨다. 
        //if (m_drag_image != null) { 
        //    PointerEventData pointer_data = (PointerEventData)data; 
        //    m_drag_image.transform.position = pointer_data.position; 
        //} 
    } 
        
    public void OnEndDrag(BaseEventData data) 
    {
        print("OnDragEnd");
        ////드랍 했을 때, 생성한 이미지를 없앤다.         
        //if (m_drag_image != null) { 
        //    UnityEngine.Object.Destroy(m_drag_image.gameObject); 
        //    m_drag_image = null; 
        //} 
    }
*/
