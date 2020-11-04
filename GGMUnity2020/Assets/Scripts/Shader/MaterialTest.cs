using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    void Start()
    {
        //Create a new cube primitive
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //Get the Renderer component from the new cube
        var kRenderer = go.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        kRenderer.material.SetColor("_Color", Color.red);
    }
}
