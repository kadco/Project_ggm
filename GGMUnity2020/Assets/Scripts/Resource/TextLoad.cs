using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI;

public class TextLoad : MonoBehaviour
{
    //public Text ttt;

    void Start()
    {
        TextAsset data = Resources.Load("Text/TextLoad", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(data.text);
        string line = sr.ReadLine();
        while (line != null)
        {
            Debug.Log(line); //ttt.text = line;

            line = sr.ReadLine();            
        }        
    }
        
    void Update()
    {
        
    }

}
