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

/*
 // Act -------------------------------------
public enum eAct // animation + transform + state
{
    None,
    idle,
    walk,
    attack,     // target
    hit,       
    die,
    Max
};
public eAct kAct_cur;           //액션
public eAct kAct_old;
public float fAct_time = 0.0F;   //액션 시간.

public int Act_start()
{
    kAct_old = kAct_cur;
    kAct_cur = _act;

    switch (kAct_cur)
    {
        case eAct.appear:			
			break;
		case eAct.idle:
            MoveSpeed = 0.0f;
            Animation_set("idle");
			break;
		case eAct.walk:
            MoveSpeed = 2.0f;
            Animation_set("walk");
			break;
		case eAct.attack:
            MoveSpeed = 0.0f;
            Animation_set("attack");
            fAct_time = Time.time + 0.5f;  //공격 애니 동작.
			break;
    }
    return 0;
}

public int Act_update()
{
    switch (kAct_cur)
    {
        case eAct.appear:
			Act_start(eAct.idle);
			break;
		case eAct.idle:
			break;
		case eAct.walk:
			break;
		case eAct.attack:
            if (Time.time >= fAct_time) Act_start(eAct.idle);
			break;
    }
    return 0;
}
*/
