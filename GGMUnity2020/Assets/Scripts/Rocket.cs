using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public GameObject wreck;

    bool bActive = false;
    float movespeed = 1.0f;

    public void Fire( Transform dir)
    {
        transform.position = dir.position;
        transform.rotation = dir.rotation;

        Destroy(gameObject, 3.0f);
        bActive = true;
    }

    private void Update()
    {
        if (!bActive) return;
        transform.position = transform.position + transform.forward * movespeed;
    }

    void OnCollisionEnter(Collision other)
    {
        print("Rocket OnCollisionEnter " + other.transform.name);
        Destroy(gameObject);
    }
}


/*
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        KillSelf();
    }
    void KillSelf()
    {
        // Instantiate the wreck game object at the same position we are at
        //GameObject wreckClone = (GameObject)Instantiate(wreck, transform.position, transform.rotation);
        //if(wreckClone)  wreckClone.GetComponent<MyScript>().someVariable = GetComponent<MyScript>().someVariable;

        // Kill ourselves
        Destroy(gameObject);
    } 
*/
