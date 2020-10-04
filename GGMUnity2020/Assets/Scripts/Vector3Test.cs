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
    public Transform tran1;
    public Transform tran2;
        
    void Start()
    {
        tran1.position = new Vector3(0, 0, 0);
        tran1.position = Vector3.zero;  //Vector3.one;

        tran1.forward = Vector3.left;  //전진 방향 //Vector3.forward

        print(tran2.position.magnitude);  //길이 //피타고라스의 정리

        Vector3 v = tran2.position.normalized; print(v.x + " " + v.y + " " + v.z ); //단위 백터

        Vector3 v2 = tran1.position + tran2.position;  //백터 더하기
        Vector3 v3 = tran2.position - tran1.position;  //백터 빼기 //타겟 - 시작 = 타겟까지의 벡터(길이+방향)
        float dist = v3.magnitude;          //길이
        Vector3 dir = v3.normalized;        //방향

        Vector3 v4 = tran1.position * 3;  // 벡터 곱하기 //동일한 방향으로 증가

        Vector3 dir2 = v3.normalized * 2;                   // 방향 * 초당 이동 거리 = 초당 이동할 거리 벡터
        Vector3 dir3 = v3.normalized * 2 * Time.deltaTime;  // 프레임 기간동안 이동할 거리 벡터

        float dot = Vector3.Dot(tran1.position, tran2.position); print(dot);  //벡터의 내적 //두백터의 각도 0이면 직각.

        Vector3 cross = Vector3.Cross(tran1.position, tran2.position);      //벡터의 외적 //직각인 벡터 찾기 
    }

    void Update()
    {
        //float dot = Vector3.Dot(tran1.position, tran2.position); print(dot);
    }
}
