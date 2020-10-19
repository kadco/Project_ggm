using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest2 : MonoBehaviour
{
    public Color colorStart = Color.red;
    public Color colorEnd = Color.yellow;
    public float duration = 1.0F;
    Renderer kRenderer;

    void Start()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        kRenderer = go.GetComponent<Renderer>();
    }
    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        for (int i = 0; i < kRenderer.materials.Length; i++)
        {
            kRenderer.materials[i].color = Color.Lerp(colorStart, colorEnd, lerp);
        }
    }
}
