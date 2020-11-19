using System.Collections;
using System.Collections.Generic;

using UnityEngine;

// SpriteRenderer

public class FadeInOut2 : MonoBehaviour
{
    float FadeTime = 2f;
    float time;
    bool bFadeIn = false;
    bool bFadeOut = false;

    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {        
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    FadeInStart();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    FadeOutStart();
        //}

        if (bFadeIn) FadeIn();
        if (bFadeOut) FadeOut();
    }

    public void FadeInStart(float fadetime = 2f)
    {
        FadeTime = fadetime;
        time = 0; bFadeIn = true;
    }

    public void FadeOutStart(float fadetime = 2f)
    {
        FadeTime = fadetime;
        time = 0; bFadeOut = true;
    }

    void FadeIn()
    {
        if (time < FadeTime)
            sprite.color = new Color(1, 1, 1, time/ FadeTime);
        else
            bFadeIn = false;

        time += Time.deltaTime;
    }

    void FadeOut()
    {
        if (time < FadeTime)
            sprite.color = new Color(1, 1, 1, 1f - time/ FadeTime);
        else
            bFadeOut = false;

        time += Time.deltaTime;
    }
}
