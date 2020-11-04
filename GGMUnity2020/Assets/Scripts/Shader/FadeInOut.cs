using System.Collections;
using System.Collections.Generic;

using UnityEngine;

// SpriteRenderer

public class FadeInOut : MonoBehaviour
{
    public float _fadeTime = 2f;

    float time;

    bool bFadeIn = false;
    bool bFadeOut = false;

    SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            time = 0; bFadeIn = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            time = 0; bFadeOut = true;
        }

        if (bFadeIn) FadeIn();
        if (bFadeOut) FadeOut();
    }

    void FadeIn()
    {
        if (time < _fadeTime) {
            spr.color = new Color(1, 1, 1, time/_fadeTime);
        }
        else {
            bFadeIn = false;
        }
        time += Time.deltaTime;
    }
    void FadeOut()
    {
        if (time < _fadeTime) {
            spr.color = new Color(1, 1, 1, 1f - time/_fadeTime);
        }
        else {
            bFadeOut = false;
        }
        time += Time.deltaTime;
    }
}
