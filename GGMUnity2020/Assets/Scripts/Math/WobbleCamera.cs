using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleCamera : MonoBehaviour
{
    Matrix4x4 orgProjection;
    void Start()
    {
        orgProjection = Camera.main.projectionMatrix;
    }

    void Update()
    {
        Matrix4x4 p = orgProjection;
        p.m01 += Mathf.Sin(Time.time * 1.2f) * 0.1f;
        p.m10 += Mathf.Sin(Time.time * 1.5f) * 0.1f;
        Camera.main.projectionMatrix = p;
    }
}
