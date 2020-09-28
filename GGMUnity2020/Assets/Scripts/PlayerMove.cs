using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float movespeed = 4.0f;
    float spinspeed = 180f;

    float jumpspeed = 4.0f;     //점프하여 도약하는 속도
    float JumpTime = 0.4f;      //점프하여 도약하는 시간
    float Jumpstarttime;        //점프 시작 시간
    bool bJump = false;
    bool bJumpup = false;
    bool bDown = false;

    public Transform target;

    void Start()
    {

    }

    void Update()
    {
        //좌표이동
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += Vector3.right * movespeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position += Vector3.left * movespeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += Vector3.forward * movespeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position += Vector3.back * movespeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) //충돌판정에는 양쪽다 collider 필요, 한쪽엔 rigibody
    {
    }

    void OnCollisionEnter(Collision other) //충돌지점 계산 //물리연산
    {
    }
}

/*    
    //좌표이동
    if (Input.GetKey(KeyCode.RightArrow)) transform.position += Vector3.right * movespeed * Time.deltaTime;
    if (Input.GetKey(KeyCode.LeftArrow))  transform.position += Vector3.left * movespeed * Time.deltaTime;
    if (Input.GetKey(KeyCode.UpArrow))    transform.position += Vector3.forward * movespeed * Time.deltaTime; 
    if (Input.GetKey(KeyCode.DownArrow))  transform.position += Vector3.back * movespeed * Time.deltaTime;
*/

/*    
    Vector3 pos_old = transform.position; //방향계산을 위해 이전 좌표 저장 

    //좌표이동
    if (Input.GetKey(KeyCode.RightArrow)) transform.position += Vector3.right * movespeed * Time.deltaTime;
    if (Input.GetKey(KeyCode.LeftArrow))  transform.position += Vector3.left * movespeed * Time.deltaTime;
    if (Input.GetKey(KeyCode.UpArrow))    transform.position += Vector3.forward * movespeed * Time.deltaTime; 
    if (Input.GetKey(KeyCode.DownArrow))  transform.position += Vector3.back * movespeed * Time.deltaTime;

    //방향전환
    Vector3 dir = transform.position - pos_old; dir.y = 0;
    Vector3 pos = transform.position + dir * 1;
    transform.LookAt(pos);
*/

/*   
    //좌우 회전
    if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(Vector3.up * spinspeed * Time.deltaTime);
    if (Input.GetKey(KeyCode.LeftArrow))  transform.Rotate(-Vector3.up * spinspeed * Time.deltaTime);   
    //전진 이동
    if (Input.GetKey(KeyCode.UpArrow))    transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    if (Input.GetKey(KeyCode.DownArrow))  transform.Translate(-Vector3.forward * movespeed * Time.deltaTime);
*/

/*
    public Transform target; //타겟
     
    //타겟 이동
    transform.LookAt(target.position);
    transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
*/


/*
//Unity의 회전 및 오리엔테이션
//https://docs.unity3d.com/kr/current/Manual/QuaternionAndEulerRotationsInUnity.html

float x;
void Update()
{
    x += Time.deltaTime * 10;
    transform.rotation = Quaternion.Euler(x, 0, 0);
}
*/
