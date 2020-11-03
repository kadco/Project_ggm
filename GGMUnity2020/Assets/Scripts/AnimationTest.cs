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

    }

    void Update()
    {
    }

    //에니메이션 이벤트 
    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
}
