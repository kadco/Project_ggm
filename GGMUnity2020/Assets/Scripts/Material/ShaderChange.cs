using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChange : MonoBehaviour
{
    // Toggle between Diffuse and Transparent/Diffuse shaders
    // when space key is pressed

    Shader shader1;
    Shader shader2;
    Renderer render;


    void Start()
    {
        render = GetComponent<Renderer>();
        shader1 = Shader.Find("Diffuse");
        shader2 = Shader.Find("Transparent/Diffuse");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (render.material.shader == shader1)
            {
                render.material.shader = shader2;
            }
            else
            {
                render.material.shader = shader1;
            }
        }
    }
}