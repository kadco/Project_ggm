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

    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }
}
