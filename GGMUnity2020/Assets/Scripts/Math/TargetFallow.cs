using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFallow : MonoBehaviour
{
    public Transform target;
    float speed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = target.position - transform.position;
        Vector3 dir = vec.normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}
