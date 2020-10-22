using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCtrl : MonoBehaviour
{
    private Transform _transform;
    private bool isJumping;
    private float posY;        //오브젝트의 초기 높이
    private float gravity;     //중력가속도
    private float jumpPower;   //점프력
    private float jumpTime;    //점프 이후 경과시간

    void Start()
    {
        _transform = transform;
        isJumping = false;
        posY = transform.position.y;
        gravity = 9.8f;
        jumpPower = 7.0f;
        jumpTime = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            posY = _transform.position.y;
        }

        if (isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        //점프시간을 증가시킨다.
        jumpTime += Time.deltaTime;

        //y = -a*t + v 에서 (a: 중력가속도, v: 초기 점프속도) 적분하여 
        //y = (-a/2)*t*t + (v*t) 공식을 얻는다.(t: 점프시간, y: 오브젝트의 높이)

        //변화된 높이 height를 기존 높이 _posY에 더한다.
        float height = (jumpTime * jumpTime * (-gravity) / 2) + (jumpTime * jumpPower);
        transform.position = 
            new Vector3(transform.position.x, posY + height, transform.position.z );

        //처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
        if (height < 0.0f)
        {
            isJumping = false;
            jumpTime = 0.0f;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
    }

}

/*
    // check 점프
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (!bJump && !bDown) {
            Jumpstarttime = Time.time; 
            bJump = true;
        }
    }
    if (bJump)
    {
        float jspeed = jumpspeed - (Time.time - Jumpstarttime) * 9.8f; //중력가속도
        transform.position += Vector3.up * jspeed * Time.deltaTime;
        if (Time.time >= Jumpstarttime + JumpTime) { bJump = false; }
    } 
*/


