using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 편집 : Window / AI / Navigation  
// 대상 : 편집창 Object 에서  / Navigation Static, Navigation Area 설정
// 이동 : Component / Navigation / Nav Mesh Agent

public class NavigationTest : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.enabled = true; //초기화
            agent.speed = 2;
        }
    }

    void Update()
    {
        if (Input.anyKey && target != null)
        { 
            agent.SetDestination(target.position);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (true == (Physics.Raycast(ray.origin, ray.direction * 1000, out hit)))
        //    {
        //        //print(hit.collider.gameObject.name);
        //        if (hit.collider.gameObject.name == "Plane")
        //            if (agent != null)
        //            {
        //                agent.speed = 2;
        //                agent.SetDestination(hit.point);
        //            }
        //    }
        //}
        
    }
}
