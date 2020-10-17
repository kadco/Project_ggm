using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //선언필요

public class TestUI : MonoBehaviour
{
    public Text m_text;
    public Image m_image;
    public Button m_button;
    public Toggle m_toggle;
    public Slider m_slider;
    public InputField m_input;

    void Start()
    {
        m_text.text = "hello";

        m_image.color = Color.white;
        m_image.sprite = Resources.Load<Sprite>("Sprite/flag") as Sprite;

        print(m_button.gameObject.name);
        m_button.onClick.AddListener(OnClick_Button);

        print(m_toggle.isOn);
        m_toggle.onValueChanged.AddListener(delegate {onValueChanged_toggle(m_toggle); });

        m_slider.value = 0.4f;
        m_slider.onValueChanged.AddListener(delegate { onValueChanged_slider(); });

        m_input.onValueChanged.AddListener(delegate { onValueChanged_input(); });

        //m_image.transform.SetAsLastSibling();  //순서변경
    }

    void Update()
    {
        //if (m_input.text != "") print(m_input.text);
    }

    public void OnClick_Button()
    {
        print("Button click");
    }

    public void onValueChanged_toggle(Toggle change)
    {
        m_text.text = change.name + " " + m_toggle.isOn;

        //print(change.name + " " + change.isOn);
        //if (change.name == "Toggle1" && change.isOn) print("Toggle1");
        //if (change.name == "Toggle2" && change.isOn) print("Toggle2");
    }

    public void onValueChanged_slider()
    {
        Debug.Log(m_slider.value);
    }

    public void onValueChanged_input()
    {
        Debug.Log(m_input.text);
    }
}
