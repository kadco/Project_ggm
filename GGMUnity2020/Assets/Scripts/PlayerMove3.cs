using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour //특정 포인터로 이동
{
    public Transform target;

    public float movespeed = 2f;    //에디터에서 변경
    public float rotatespeed = Mathf.PI * 4f;

    Rigidbody rigidbody; 

    Vector3 movement;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start () {
		
	}

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (true == (Physics.Raycast(ray.origin, ray.direction * 1000, out hit)))
            {
                //print(hit.collider.gameObject.name);
                target.position = hit.point;
            }
        }
    }

    void FixedUpdate()
    {
        movement = target.position - transform.position;
        if (movement.magnitude < 1.5f) return;

        rigidbody.rotation = Quaternion.LookRotation(movement);

        movement = movement.normalized * movespeed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }

}
