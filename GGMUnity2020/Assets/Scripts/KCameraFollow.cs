using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KCameraFollow : MonoBehaviour
{
    public Transform target;    //바라볼 대상
    public float dist = 10.0f;
    public float height = 5.0f;
    public float smoothRotate = 5.0f;   //회전

    Transform tr;  //카메라의 위치

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        //이동
        if (Input.GetKey(KeyCode.UpArrow))      target.position += target.forward * 1.0f * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))    target.position += -target.forward * 1.0f * Time.deltaTime;

        //회전
        if (Input.GetKey(KeyCode.RightArrow))   target.RotateAround(target.position, Vector3.up, 90 * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))    target.RotateAround(target.position, Vector3.up, -90 * Time.deltaTime);
    }

        
    void LateUpdate()
    {
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, currYAngle, 0); //타겟 회전값

        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);  
        //tr.position = target.position - (Vector3.forward * dist) + (Vector3.up * height);  //rot 반영안하면 고정 시점

        tr.LookAt(target);
    }
}
