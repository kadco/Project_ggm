using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Test : MonoBehaviour
{
    void Start()
    {
        //피타고라스 정리  
        print( Mathf.Pow(4, 2) );
        print( Mathf.Sqrt(16) );

        float a = 4; //(4,3)
        float b = 3;
        float c = Mathf.Sqrt( Mathf.Pow(a, 2) + Mathf.Pow(b, 2) );
        print(c);

        //디그리, 라디안
        float rad = 180 * Mathf.Deg2Rad;        print(rad);
        float deg = Mathf.PI * Mathf.Rad2Deg;   print(deg);

        //각도로 위치,방향 만들기
        float distance = 1;
        float radian = 45 * Mathf.PI / 180; //라디안값
        float x = Mathf.Cos(radian);
        float y = Mathf.Sin(radian);
        print(x + ", " + y);
        Vector3 vec = new Vector3(x, y, 0);
        Vector3 dir = vec.normalized;
        Vector3 pos = dir * distance;
        print(pos.ToString());

        // 좌표로 각 구하기
        Vector3 velocity = new Vector3(1, 1, 0); //(1, -1, 0);
        Vector3 direction = velocity.normalized;
        float degree = Mathf.Atan(velocity.y / velocity.x) * Mathf.Rad2Deg;
        print(degree.ToString());
    }

}

