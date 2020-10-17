using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    Text text; 
    
    void Start () 
    {
        text = GetComponent<Text>(); 
        StartCoroutine( StartBlink() ); 
    } 
    
    public IEnumerator StartBlink()
    { 
        while (true) {
            text.text = ""; 
            yield return new WaitForSeconds (.5f);
            text.text = "Spacebar to Start"; 
            yield return new WaitForSeconds (.5f); 
        }
    }
}
