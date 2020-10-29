using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animation anima; //편집 //Ctrl+6

    Animator anim;          //Animator, Animator Controller, AnimatorClip

    void Start()
    {
        //에니메이션
        print("" + anima.name);

        //에니메이터 얻어오기
        anim = GetComponent<Animator>();

        //에니메이션 클립 정보 얻어오기
        //AnimatorClipInfo[] clips = anim.GetCurrentAnimatorClipInfo(0); //anim.layerCount
        //for (int i = 0; i < clips.Length; i++)
        //{
        //    print("clip:" + clips[i].clip.name + " length:" + clips[i].clip.length);
        //}

        //anim.speed = 2.0f;  //스피드변경
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.Play("idle");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.Play("walk");
            //anim.CrossFade("walk", 0.3f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.speed = 1.0f;
            anim.Play("death");
            Invoke("SetAnimation", 1.0f);
        }
    }

    void SetAnimation()
    {
        anim.Play("idle");
    }
}
