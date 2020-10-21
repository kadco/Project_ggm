using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //선언필요

public class Test : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if(Input.anyKey)
        {
            //GameSnd.Instance.Sound_play("snd_ui_click");
            GameSnd.Instance.PlaySound("snd_ui_click");
        }
    }
}

