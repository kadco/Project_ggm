using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    
    float movespeed = 4.0f;
    float spinspeed = 180f;

    float jumpspeed = 5.0f;     //점프하여 도약하는 속도
    float JumpTime = 0.4f;      //점프하여 도약하는 시간
    float Jumpstarttime;        //점프 시작 시간
    bool bJump = false;    
    bool bJumpup = false;

    bool bDown = false;

    //Transform target;

    void Start ()
    {

    }

    void Update ()
    {

        Vector3 pos_old = transform.position;

        //이동
        if (Input.GetKey(KeyCode.RightArrow))            
            transform.position += Vector3.right * movespeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * movespeed * Time.deltaTime;
        //if (Input.GetKey(KeyCode.UpArrow))
        //    transform.position += Vector3.forward * movespeed * Time.deltaTime; 
        //if (Input.GetKey(KeyCode.DownArrow))
        //    transform.position += Vector3.back * movespeed * Time.deltaTime;


        // check 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!bJump && !bDown)
            {
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

        // check MoveDown
        if (!bJump)
        {
            RaycastHit hit;
            GameObject target = null;
            if (true == Physics.Raycast(transform.position, -transform.up, out hit, 0.1f) ) //일정 거리 레이캐스트
            {
                target = hit.collider.gameObject; //있으면 오브젝트를 저장한다.
                //print("target " + target.name);
            }
            if (target != null && target.name.Contains("ground"))   { bDown = false; }
            else                                                    { bDown = true; }
        }
        if (bDown)
        {
            transform.position += Vector3.down * jumpspeed * Time.deltaTime;
        }

        //방향전환
        Vector3 dir = transform.position - pos_old; dir.y = 0;
        Vector3 pos = transform.position + dir.normalized;
        transform.LookAt(pos);
    }

    void OnTriggerEnter(Collider other) //충돌판정에는 양쪽다 collider 필요, 한쪽엔 rigibody
    {
        //print("player OnTriggerEnter " + other.name);

        if (other.name.Contains("ground") && !bJump)  bDown = false;
    }

    void OnCollisionEnter(Collision other) //충돌지점 계산 //물리연산
    {
        //print("player OnCollisionEnter " + other.transform.name);
    }
}

/*
    
{
    //전진 이동
    if (Input.GetKey(KeyCode.UpArrow))
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    if (Input.GetKey(KeyCode.DownArrow))
        transform.Translate(-Vector3.forward * movespeed * Time.deltaTime);
    //좌우 회전
    if (Input.GetKey(KeyCode.RightArrow))
        transform.Rotate(Vector3.up * spinspeed * Time.deltaTime);
    if (Input.GetKey(KeyCode.LeftArrow))
        transform.Rotate(-Vector3.up * spinspeed * Time.deltaTime);
}


//이름이나 태그로 게임 오브젝트 찾기

GameObject player;
GameObject[] enemies;

void Start()
{
    player = GameObject.Find("MainHeroCharacter");
    player = GameObject.FindWithTag("Player");
    enemies = GameObject.FindGameObjectsWithTag("Enemy");
}

//태그 예제
public GameObject respawnPrefab;
public GameObject respawn;
void Start()
{
    if (respawn == null) respawn = GameObject.FindWithTag("Respawn");
    Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation) as GameObject;
}

//Unity의 회전 및 오리엔테이션
//https://docs.unity3d.com/kr/current/Manual/QuaternionAndEulerRotationsInUnity.html

float x;
void Update()
{
    x += Time.deltaTime * 10;
    transform.rotation = Quaternion.Euler(x, 0, 0);
}
*/
