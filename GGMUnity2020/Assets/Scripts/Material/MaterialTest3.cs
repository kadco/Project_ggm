using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest3 : MonoBehaviour
{
    public Texture texture;
    Renderer render;

    void Start()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        render = go.GetComponent<Renderer>();

        render.material.SetTexture("_MainTex", texture);

        //if (render.material.HasProperty("_Color"))
        //    render.material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

