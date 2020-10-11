using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Key_Int", 1);
        PlayerPrefs.SetFloat("Key_Float", 2.0f);
        PlayerPrefs.SetString("Key_String", "nickame");

        int iValue = PlayerPrefs.GetInt("Key_Int");
        float fValue = PlayerPrefs.GetFloat("Key_Float");
        string strValue = PlayerPrefs.GetString("Key_String");

        if(!PlayerPrefs.HasKey("Key_Code"))
        {
            PlayerPrefs.SetString("Key_Code", "15D15QW25");
        }    
    }

    void Update()
    {

    }
}

/*
PlayerPrefs

저장하기

        PlayerPrefs.SetInt("Key_Int", 1);
        PlayerPrefs.SetFloat("Key_Float", 2.0f);
        PlayerPrefs.SetString("Key_String", "nickame");

PlayerPrefs 에 각 자료형에 맞게 key 를 지정 후 값을 넣어주면 됩니다.

불러오기

저장할때 사용한 Key 를 통해서 불러오면 됩니다.

int iValue = PlayerPrefs.GetInt("Key_Int");
float fValue = PlayerPrefs.GetFloat("Key_Float");
string strValue = PlayerPrefs.GetString("Key_String");


특정 key 존재 확인

PlayerPrefs.HasKey("Key_Name");

HasKey 는 키값이 존재하면 true 를 반환합니다.
앱 실행 시 HasKey를 사용해서 키값이 있는지 확인하고 없다면 사용하려는 키의 초기값을 넣는데 사용. 


PlayerPrefs.Save(); // 저장하기
PlayerPrefs.DeleteAll(); // 모두 삭제하기
PlayerPrefs.DeleteKey("Key_Name"); // key 삭제하기

*/
