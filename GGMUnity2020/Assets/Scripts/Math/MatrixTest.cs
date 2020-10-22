using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixTest : MonoBehaviour
{
    public Text matrixTxt1;
    public Text matrixTxt2;
    public Text matrixTxt3;

    void Start()
    {        
    }

    void Update()
    {
        DisplayMatrix();
    }

    void DisplayMatrix()
    {
        Matrix4x4 matrix = transform.localToWorldMatrix;
        matrixTxt1.text = "" + matrix;
        matrixTxt2.text = "" + matrix.inverse;
        matrixTxt3.text = "" + matrix.transpose;
    }


}
