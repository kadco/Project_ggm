using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera cam1;     
    public Camera cam2;     // 카메라가 여러개면 Depth 에 따라 카메라 순서 결정 

    void Start()
    {
        //print(Camera.main.name); // 모두 테그를 MainCamera 로 세팅
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.enabled = true;
            cam2.enabled = false;
            print(Camera.main.name); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam2.enabled = true;
            cam1.enabled = false;            
            print(Camera.main.name);
        }
    }
}
