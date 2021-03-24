using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 물리 // Rigidbody / Use Gravite 사용

public class PlayerMove2 : MonoBehaviour // 키보드 이동 //물리가 적용된 이동
{    
    public float movespeed = 5f;    //에디터에서 변경
    public float jumppower = 6f;
    public float rotatespeed = Mathf.PI * 2f;

    Rigidbody rigidbody; 

    Vector3 movement;
    float h_move;
    float v_move;
    bool isJumping = false;
    bool isGround = true;

    //public Transform firepoint;
    //public Rigidbody rocket;
    //float rocket_speed = 10f;
    

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start () {
		
	}

    void Update ()
    {
        h_move = Input.GetAxisRaw("Horizontal"); 
        v_move = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGround) Jump();
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    //FireRocket();
        //}
    }

    void FixedUpdate()
    {
        Run();
        Turn();        
    }

    void Run()
    {
        movement.Set(h_move, 0, v_move);
        movement = movement.normalized * movespeed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        if (h_move == 0 && v_move == 0) return;
        //rigidbody.rotation = Quaternion.LookRotation(movement);
        Quaternion newRotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, rotatespeed * Time.deltaTime);
    }

    void Jump()
    {
        //print("Jump");
        isJumping = true;
        isGround = false;
        rigidbody.AddForce(Vector3.up * jumppower, ForceMode.Impulse);        
    }

    void OnCollisionEnter(Collision other)
    {
        print("player OnCollisionEnter " + other.transform.name);
        if (other.transform.name.Contains("ground"))
        {
            isGround = true;
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider other) //충돌판정에는 양쪽다 collider 필요, 한쪽엔 rigibody
    {
        print("OnTriggerEnter " + other.name);
    }


    //void FireRocket()
    //{
    //    Rigidbody rocketClone = (Rigidbody)Instantiate(rocket, firepoint.position, firepoint.rotation);
    //    rocketClone.velocity = transform.forward * rocket_speed;

    //    //rocketClone.GetComponent<Rocket>().DoSomething();
    //}
}
