using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class kFallowTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 vec = target.position - transform.position;     //타겟까지의 벡터
        Vector3 dir = vec.normalized;                           //단위벡터, 방향
        transform.position += dir * speed * Time.deltaTime;     //시간당 방향 * 속력 = 이번 프레임에 이동할 거리 

        //transform.LookAt(target);
    }
}
