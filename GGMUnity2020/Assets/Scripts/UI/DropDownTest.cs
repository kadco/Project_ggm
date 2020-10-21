using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownTest : MonoBehaviour
{
    public Dropdown m_dropdown;

    void Start()
    {
        m_dropdown.captionText.text = "목록";
        m_dropdown.onValueChanged.AddListener(SelectButton);

        SetDropdownOptionsExample();        
    }

    void Update()
    {
        if (Input.anyKeyDown) { }            
    }

    private void SetDropdownOptionsExample() // Dropdown 목록 생성
    {
        m_dropdown.options.Clear();
        for (int i = 1; i <= 5; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = i.ToString() + "갯수";
            m_dropdown.options.Add(option);
        }
    }

    public void SelectButton(int index) // SelectButton을 누름으로써 값 테스트.
    {
        Debug.Log(index);
        Debug.Log("Dropdown Value: " + m_dropdown.value);
    }
}
