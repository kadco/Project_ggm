using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        //GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);

        //Quaternion lookAt = Quaternion.identity;    // Querternion 함수 선언
        //Vector3 tarPos = target.transform.position; tarPos = new Vector3(tarPos.x, 0, tarPos.z); //높이 제거        
        //Vector3 lookatVec = (tarPos - transform.position).normalized; //( 타겟 위치 - 자신 위치).노멀라이즈
        //lookAt.SetLookRotation(lookatVec);          // 쿼터니언의 SetLookRotaion 함수 적용
        //transform.rotation = lookAt;   //최종적으로 Quternion  적용       
    }
}
