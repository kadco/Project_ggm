using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererTest : MonoBehaviour
{
    Color color = new Color(1, 1, 1, 1);
    SpriteRenderer spr;

    Color color_org;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        color_org = spr.color;

        spr.color = color;
    }

    void Update()
    {
        float flicker = Mathf.Abs(Mathf.Sin(Time.time/2f));
        spr.color = color_org * flicker;
    }
}
