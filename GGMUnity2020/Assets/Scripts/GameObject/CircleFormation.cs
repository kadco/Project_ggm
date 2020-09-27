using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFormation : MonoBehaviour
{
    // Instantiates prefabs in a circle formation

    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;

    void Start()
    {

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects; // 
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);

            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);

            Instantiate(prefab, pos, rot);
        }

    }    
}

/*
    //원을 그리며 이동 ---------------------------------
    void Update()
    {
        float theta = Time.realtimeSinceStartup * 1.0f;
        Vector3 vec = Vector3.zero; 
        GetPos(ref vec, theta);
        transform.position = vec;
    }

    void GetPos( ref Vector3 v, float theta)
    {
        v.x += Mathf.Cos(theta);
        v.y += Mathf.Sin(theta);
    } 

    //속도를 이용하여 기울기 만들기 ----------------------
    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 dir = velocity.normalized;
        float degree = Mathf.Atan(dir.x / dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }

    //바라보는 방향이 비슷 -----------------------------
    if( Vector3.Dot(dir.normalized, transform.forward) > 0 )
    {        
    }

    // DisplayMatrix 매트릭스 ------------------------------------------
    Text MyText;
    void Update()
    {
        Matrix4x4 mx = gameObject.GetComponent<Transform>().localToWorldMatrix;
        string txt; 
        txt += string.Format("{0:0.00} {1:0.00} {2:0.00} {3:0.00}\n", mx.m00, mx.m01, mx.m02, mx.m03);
        txt += string.Format("{0:0.00} {1:0.00} {2:0.00} {3:0.00}\n", mx.m10, mx.m11, mx.m12, mx.m13);
        txt += string.Format("{0:0.00} {1:0.00} {2:0.00} {3:0.00}\n", mx.m20, mx.m21, mx.m22, mx.m23);
        txt += string.Format("{0:0.00} {1:0.00} {2:0.00} {3:0.00}\n", mx.m30, mx.m31, mx.m32, mx.m33);
        MyText.text = txt;
    }

    //Matrix4x4 mx = gameObject.GetComponent<Transform>().localToWorldMatrix;        
    //mx.inverse  //MakeInverseMatrix(Matrix4x4 matrix) {}
    //mx.transpose
    
    //world
    transform.localToWorldMatrix
    //view
    Camera.main.worldToCameraMatrix
    //projection
    Camera.main.projectionMatrix

*/
