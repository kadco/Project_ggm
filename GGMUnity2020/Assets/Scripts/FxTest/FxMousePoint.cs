using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxMousePoint : MonoBehaviour
{
    public Transform target;  //fx 를 UI 위에 띄운다. Screen Camera, Canvas Order in Layer

    void Update()
    {
        if (Input.GetMouseButton(0))  // 마우스가 클릭 되면
        {
            Vector3 hit_pos = GetRaycastObjectPoint();
            if(hit_pos != Vector3.zero)
            { 
                target.position = hit_pos; // 타겟을 레이캐스트가 충돌된 곳으로 옮긴다.
            }
        }
    }

    public Vector3 GetRaycastObjectPoint()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (true == (Physics.Raycast(ray.origin, ray.direction, out hit, 1000)))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
