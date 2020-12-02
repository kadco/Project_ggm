using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest3 : MonoBehaviour
{
    public Texture texture;
    Renderer kRenderer;

    void Start()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        kRenderer = go.GetComponent<Renderer>();

        kRenderer.material.SetTexture("_MainTex", texture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
