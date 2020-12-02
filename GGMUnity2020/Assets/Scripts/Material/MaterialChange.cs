using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    Renderer render;

    void Start()
    {
        render = GetComponent<Renderer>();
        
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            render.material = mat1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            render.material = mat2;
        }
    }
}
