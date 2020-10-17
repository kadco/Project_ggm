using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    void Start()
    {
        //Create a new cube primitive to set the color on
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        
        //Get the Renderer component from the new cube
        var cubeRenderer = cube.GetComponent<Renderer>();
        
        //Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_Color", Color.red);
    }

}
