using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreate : MonoBehaviour
{
    void Start()
    {
        //큐브 생성하기 //PrimitiveType.Cube
        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube); 
        box.transform.position = new Vector3(0, 0, 0);

        //MakeWall();

        //랜덤
        //int rnd = UnityEngine.Random.Range(0, 5);
        //print(rnd);

        //MakeCube();
    }

    void MakeWall()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(i, j, 0);
                go.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            }
        }
    }

    void MakeCube()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int r = UnityEngine.Random.Range(0, 7);
                for (int z = 0; z < r; z++)
                {
                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    go.transform.position = new Vector3(i, z, j);
                    go.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

                    //Renderer render = go.GetComponent<Renderer>();
                    //if (render) render.material.color = new Color(1,0,0);
                }
            }
        }
    }
}
