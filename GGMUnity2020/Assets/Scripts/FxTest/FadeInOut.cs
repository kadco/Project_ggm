using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public GameObject go;
//
//FadeInOut fade = go.GetComponent<FadeInOut>();
//fade.StartFadeOut(3);

public class FadeInOut : MonoBehaviour
{    
    float FadeTime = 2f; // Fade효과 재생시간
    Image fadeImg;
    float start = 0f;
    float end = 1f;
    float time = 0f;
    bool isPlaying = false;

    void Awake()
    {
        fadeImg = GetComponent<Image>();
        //StartFadeOut(3.0f);
    }
    public void StartFadeIn(float time)
    {
        if (isPlaying == true) return;
        FadeTime = time;        
        StartCoroutine("fadeinplay");
    }
    public void StartFadeOut(float time)
    {
        if (isPlaying == true) return;
        FadeTime = time;        
        StartCoroutine("fadeoutplay");    //코루틴 실행
    }

    IEnumerator fadeinplay()
    {
        isPlaying = true;
        time = 0f; start = 0f; end = 1f;
        Color fadecolor = fadeImg.color;
        fadecolor.a = Mathf.Lerp(start, end, time);
        while (fadecolor.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            yield return null;
        }
        isPlaying = false;
    }

    IEnumerator fadeoutplay()
    {
        isPlaying = true;
        time = 0f; start = 1f; end = 0f;
        Color fadecolor = fadeImg.color;        
        fadecolor.a = Mathf.Lerp(start, end, time);
        while (fadecolor.a > 0f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImg.color = fadecolor;
            yield return null;
        }
        isPlaying = false;
    }
}