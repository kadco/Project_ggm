using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AnimatorBlend : MonoBehaviour
{
    Animator anim;

    bool isMove = false;
    bool isJump = false;
    bool isFall = false;
    bool isGround = true;

    float h_move;
    float v_move;
    Vector3 movement;

    float movespeed = 2;
    float jumppower = 9;

    Rigidbody rigid;
        
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {        
        h_move = Input.GetAxisRaw("Horizontal");
        v_move = Input.GetAxisRaw("Vertical");
        //print(h_move + " " + v_move);
        movement = new Vector3(h_move, 0, v_move);

        isMove = false;
        if (movement != Vector3.zero)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            Jump();
        }
        if(isJump && !isFall)
        {
            if(rigid.velocity.y < -0.1f)
            {
                isFall = true;
                anim.Play("Player3D_fall");
            }
        }
    }

    void Move()
    {
        isMove = true;
        transform.Translate(movement.normalized * movespeed * Time.deltaTime);
        anim.SetBool("Move", isMove);
        anim.SetFloat("Xdir", movement.x);
        anim.SetFloat("Zdir", movement.z);
    }
        
    void Jump()
    {
        isJump = true;
        isGround = false;
        anim.SetTrigger("Jump");
        rigid.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
        
    }
    void OnCollisionEnter(Collision other)
    {
        //print("player OnCollisionEnter " + other.transform.name);
        if (other.transform.name.Contains("ground"))
        {            
            isJump = false;
            isFall = false;
            isGround = true;
            //anim.Play("Player3D_idle");
        }
    }
}
