using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransform : MonoBehaviour {

    //변수와 인스펙터
    public string myName;   //인스펙터창에서 변경 가능 
    float movespeed = 0.1f;

    //게임오브젝트와 변수 연결
    public GameObject player;

    

    void Start ()
    {
        //스크립트가 소속된 객체 표시 --------------------------

        //객체 이름 출력
        print(gameObject.name);
        //위치 좌표 출력
        Vector3 pos = gameObject.transform.position;
        print(pos.x + "," + pos.y);
        //위치 좌표 입력
        gameObject.transform.localPosition = new Vector3(1f, 0f, 0f);
        transform.localPosition = new Vector3(1, 0, 0);
        //회전
        transform.rotation = Quaternion.Euler(0, 90, 0);

        //활성,비활성 -------------------------------------------
        //gameObject.SetActive(false);

        //객체 생성 ---------------------------------------------

        //선언된 오브젝트 생성
        //GameObject obj = Instantiate(player);

        //빈 오브젝트 만들기
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //오브젝트 불러오기
        //GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("cube"));


        //GameObject 컴포넌트 불러오기 ---------------------------

        //Player p = player.GetComponent<Player>();
        //print(p.nickname);

        //컴포넌트를 사용하여 게임 오브젝트 제어        
        //Transform tr = GetComponent<Transform>();
        //if (tr != null)
        //{
        //    print(tr.position.x); //위치 출력
        //}

        //게임 오브젝트 찾기 ----------------------------------------
        //GameObject moon = GameObject.Find("moon");

        //자식 게임 오브젝트 찾기
        //Transform moon = transform.Find("moon");
        //if (moon != null)
        //{
        //    print("Find moon !");
        //}

        //테그로 게임오브젝트 찾기
        //GameObject go = GameObject.FindGameObjectWithTag("MyTag");
        //if (go != null)
        //{
        //    print("Find MyTag ! " + go.name);
        //}

    }

    void Update ()
    {
        ////객체 이동
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    Vector3 pos = gameObject.transform.position;
        //    pos.x += 2.0f * Time.deltaTime;
        //    gameObject.transform.position = pos;
        //}

        ////이동
        //if (Input.GetKey(KeyCode.RightArrow))
        //    transform.position = transform.position + Vector3.right * movespeed;
        //if (Input.GetKey(KeyCode.LeftArrow))
        //    transform.position = transform.position + Vector3.left * movespeed;
        //if (Input.GetKey(KeyCode.UpArrow))
        //    transform.position = transform.position + Vector3.forward * movespeed;
        //if (Input.GetKey(KeyCode.DownArrow))
        //    transform.position = transform.position + Vector3.back * movespeed;

        //if ( Input.GetKey(KeyCode.R) )
        //{
        //    //회전
        //    transform.RotateAround(Vector3.zero, Vector3.up, 90 * Time.deltaTime);
        //}

        //if (Input.GetMouseButtonDown(0))
        //{

        //}
    }

}

/*
    
//이름이나 태그로 게임 오브젝트 찾기

GameObject player;
GameObject[] enemies;

void Start()
{
    player = GameObject.Find("MainHeroCharacter");
    player = GameObject.FindWithTag("Player");
    enemies = GameObject.FindGameObjectsWithTag("Enemy");
}

//태그 예제
public GameObject respawnPrefab;
public GameObject respawn;
void Start()
{
    if (respawn == null) respawn = GameObject.FindWithTag("Respawn");
    Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation) as GameObject;
}

//GameObject[] enemies;
//enemies = GameObject.FindGameObjectsWithTag("Enemy");

//Unity의 좌표, 벡터
//https://docs.unity3d.com/kr/current/Manual/VectorCookbook.html
//Unity의 회전 및 오리엔테이션
//https://docs.unity3d.com/kr/current/Manual/QuaternionAndEulerRotationsInUnity.html

float x;
void Update()
{
    x += Time.deltaTime * 10;
    transform.rotation = Quaternion.Euler(x, 0, 0);
}

//오브젝트 생성함수
    Instantiate(enemy);
	Instantiate(brick, new Vector3(0, 0, 0), Quaternion.identity);
//삭제
    Destroy( gameObject );
    Destroy( gameObject, 0.5f ); //지연

//빈 오브젝트 만들기
	GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); 

//선언된 오브젝트 생성
	public GameObject enemy; 
	void Start() 
	{ 
	  for (int i = 0; i < 5; i++) 
	  { 
	    Instantiate(enemy); 
	  } 
	}  

//충돌함수
	void OnCollisionEnter(Collision otherObj) 
	{ 
	  if (otherObj.gameObject.name == "Missile")    
	  { 
	  } 
	}

*/

/*
    public GameObject target;

    void Start()
    {
        transform.position = Vector3.zero;              //위치 reset
        transform.rotation = Quaternion.identity;       //회전 reset
        transform.localScale = Vector3.one;             //크기 reset

        //transform.position = new Vector3(0, 30, 0);             //이동
        //transform.Translate(new Vector3(0, 30, 0));             //이동

        //transform.rotation = Quaternion.Euler(0, 30, 0);        //회전 
        //transform.Rotate(new Vector3(0, 30, 0));                //회전        
        //transform.RotateAround(Vector3.zero, Vector3.up, 30);   //회전 //축 기준  
    }

    void Update()
    {
        //transform.LookAt(target.transform);       //특정 타겟 바라보기

        //특정 타겟 로테이션
        Quaternion lookAt = Quaternion.identity;    // Querternion 함수 선언
        Vector3 tarPos = target.transform.position; tarPos = new Vector3(tarPos.x, 0, tarPos.z); //높이 제거        
        Vector3 lookatVec = (tarPos - transform.position).normalized; //( 타겟 위치 - 자신 위치).노멀라이즈
        lookAt.SetLookRotation(lookatVec);          // 쿼터니언의 SetLookRotaion 함수 적용
        transform.rotation = lookAt;   //최종적으로 Quternion  적용    

        //특정 축 기준 로테이션
        //transform.RotateAround(Vector3.zero, Vector3.up, 90 * Time.deltaTime));
    }        

    void MoveToTarget(float _speed)
    {
        transform.LookAt(target);

        //회전
        Quaternion q = transform.localRotation; q.x = 0; q.z = 0; //y축
        transform.localRotation = q;

        //이동
        Vector3 m_Move = transform.forward * _speed * Time.deltaTime;
        transform.position += m_Move;
    } 
*/
