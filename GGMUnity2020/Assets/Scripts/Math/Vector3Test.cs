/*
 * 백터
https://www.youtube.com/watch?v=7DK8aA2qee8&feature=youtu.be
*/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Vector3Test : MonoBehaviour
{
    public Transform target;
    Vector3 v1 = new Vector3(1, 0, 0);
    Vector3 v2 = new Vector3(0, 1, 0);

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.position = Vector3.zero;  //Vector3.one;


        target.forward = Vector3.left;  //전진 방향 //Vector3.forward

        print(target.position.magnitude);  //길이 //피타고라스의 정리

        Vector3 v = target.position.normalized; print(v.x + " " + v.y + " " + v.z ); //단위 백터
        Vector3 dir = target.position.normalized;        //방향
        float dist = target.position.magnitude;          //길이
        print(dist);        
        

        Vector3 v3 = v1 + v2;  //백터 더하기
        Vector3 v4 = v2 - v1;  //백터 빼기 //타겟 - 시작 = 타겟까지의 벡터(길이+방향)
        Vector3 v5 = v1 * 3;    //벡터 곱하기(스칼라배) //동일한 방향으로 증가

        Vector3 dir2 = v1.normalized * 2;                   // 방향 * 초당 이동 거리 = 초당 이동할 거리 벡터
        Vector3 dir3 = v1.normalized * 2 * Time.deltaTime;  // 프레임 기간동안 이동할 거리 벡터

        //벡터의 내적 //두 백터의 각도, 0이면 직각.
        v1 = new Vector3(0, 0, 1);
        v2 = new Vector3(1, 0, 0);
        float dot = Vector3.Dot(v1, v2); 
        print("dot: " + dot);

        //벡터의 외적 //직각인 벡터 찾기 
        Vector3 cross = Vector3.Cross(v1, v2);
        print("cross: " + cross.ToString());        
    }

    void Update()
    {
        //float dot = Vector3.Dot(target.position, transform.position); print(dot);
    }
}
