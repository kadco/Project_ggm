using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTest : MonoBehaviour
{
    public GameObject start_pos;
    public GameObject rocket;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(rocket);
            go.GetComponent<Rocket>().Fire(start_pos.transform);
        }
    }
}
