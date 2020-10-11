using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image m_drag_image;    

    void Start()
    {        
    }
    void Update()
    {      
    }

    public void OnBeginDrag(PointerEventData data)
    {
        print("OnDragBegin");
        ////드래그 시작 시, 이미지 오브젝트를 하나 생성한다. 
        //m_drag_image = Resources.Load("Image/flag", typeof(Image)) as Image;
        //m_drag_image.transform.SetParent(this.transform.parent); 
        //m_drag_image.transform.localPosition = this.transform.localPosition;
    }     

    public void OnDrag(PointerEventData data) 
    {
        print("OnDrag");
        ////생성한 이미지를, 드래그 위치에 맞춰 이동 시킨다. 
        //if (m_drag_image != null) { 
        //    PointerEventData pointer_data = (PointerEventData)data; 
        //    m_drag_image.transform.position = pointer_data.position; 
        //} 
    } 
        
    public void OnEndDrag(PointerEventData data) 
    {
        print("OnDragEnd");
        ////드랍 했을 때, 생성한 이미지를 없앤다.         
        //if (m_drag_image != null) { 
        //    UnityEngine.Object.Destroy(m_drag_image.gameObject); 
        //    m_drag_image = null; 
        //} 
    }
}
