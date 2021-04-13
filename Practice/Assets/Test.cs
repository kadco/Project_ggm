using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MyPlayer
{

}

public class Test : MonoBehaviour
{
    //자료형
    /*    10 20                 int
        1.5   3.14f           double float
        a b c 가 나           char 
        "hello"               string                 
        true, false           bool
    */




    Rigidbody rigidbody;
    float movespeed = 2.0f;
    
    void Start()
    {
        //변수 
        int level = 100;       //정수    0, +1, -1
        long exp = 10000000000000000L;
        float pi = 3.14f;       //실수    10.5   2.12345
        string name = "홍길동";
        char ch = 'A';
        bool b = true;

        print(long.MaxValue);   //-21~ 21억


        name = "박대연";
        print(name);


        rigidbody = GetComponent<Rigidbody>();

        //위치 변경
        //rigidbody.position += Vector3.forward * 2.0f * Time.deltaTime;
        //rigidbody.MovePosition(new Vector3(0, 0, 2.0f));

        //물리적 힘
        //rigidbody.AddForce(new Vector3(0, 5.0f, 0),ForceMode.Impulse);

        //속도 변경
        //rigidbody.velocity = new Vector3(0, 0, 2.0f);

        //
        //float movespeed = 2.0f;
        //transform.position += Vector3.forward * movespeed * Time.deltaTime;

        //Vector3 vec = new Vector3(1.0f, 0, 0);
        //transform.Translate(vec);

        //GameObject target = null;
        //transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) { }

        // Input //Keyboard //KeyCode
        if (Input.GetKey(KeyCode.RightArrow)) { }
        if (Input.GetKeyDown(KeyCode.A)) { }
        if (Input.GetKeyUp(KeyCode.A)) { }

        // Input //Mouse 
        if (Input.GetMouseButtonDown(0)) { }
        if (Input.GetMouseButtonUp(0)) { }

        // move //transform
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * movespeed * Time.deltaTime;
        }

        // move //rigidbody
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.position += Vector3.right * movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.position += Vector3.left * movespeed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (true == (Physics.Raycast(ray.origin, ray.direction * 1000, out hit)))
            {
                print(hit.collider.gameObject.name);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (true == (Physics.Raycast(ray.origin, ray.direction * 1000, out hit)))
            {
                print(hit.collider.gameObject.name);
                gameObject.transform.LookAt(hit.point);
            }
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Missile")
        {
            Destroy(gameObject, .5f);
        }
    }

    void OnTrriggerEnter(Collider other)
    {
        print(other.gameObject.name);
    }

}
