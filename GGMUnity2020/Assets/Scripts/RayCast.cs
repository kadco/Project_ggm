using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    { 
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (true == (Physics.Raycast(ray.origin, ray.direction * 1000, out hit)))
            {
                print( hit.collider.gameObject.name);
                //hit.point
            }
        }
    }
}

/*
    public Vector3 GetRaycastObjectPoint()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (true == (Physics.Raycast(ray.origin, ray.direction * 1000, out hit)))
        {
            return hit.point;
        }
        return Vector3.zero;
    }     
*/
