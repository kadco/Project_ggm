using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public GameObject player;
    Player playerSC;

    void Start()
    {
        //print( player.transform.position.x );
        playerSC = player.GetComponent<Player>();
        print(playerSC.speed);

    }
        
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position += new Vector3(playerSC.speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position += new Vector3(-playerSC.speed * Time.deltaTime, 0, 0);
        }
    }
}
