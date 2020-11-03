using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animation anima; //편집 //Ctrl+6

    public AnimationClip clip;
    //Animator anim;          //Animator, Animator Controller, AnimationClip

    void Start()
    {
        //에니메이션
        print("" + anima.name);

        //anima.wrapMode = WrapMode.Loop;

        //anima.clip = clip; //기본 변경.
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            anima.Play("CubeAnim2");
            //anima.PlayQueued("CubeAnim2");
            //anima.Blend("CubeAnim2");
            //anima.IsPlaying(anima.name)

        }
    }

<<<<<<< HEAD
    //에니메이션 이벤트 
=======
    //이벤트 처리 함수
>>>>>>> bac4319289bae6ab7d6eb68854afc49db3dd12e8
    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
}
