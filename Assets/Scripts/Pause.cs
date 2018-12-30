using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Pause : MonoBehaviour
{
    public GameObject m_a;
    public Transform m_canvas2;
    
    public Slider m_slider;
    public Text m_text;
    public Button m_button;
    bool m_isPause;//判断是否暂停
    // Use this for initialization
    void Start()
    {
        m_isPause = false;
        m_text = m_canvas2.transform.Find("text2").GetComponent<Text>();
        m_slider = m_canvas2.transform.Find("slider").GetComponent<Slider>();
        m_button = m_canvas2.transform.Find("button_backmenu").GetComponent<Button>();
        m_slider.transform.localPosition = new Vector3(1000, 1000, 1000);
        m_text.transform.localPosition = new Vector3(1000, 1000, 1000);
        m_button.transform.localPosition = new Vector3(1000, 1000, 1000);
        
    }

    // Update is called once per frame
    void Update()
    {
        ESC();
    }
    void ESC()//暂停的快捷键
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            m_isPause = !m_isPause;
        if (m_isPause)
        {

            Time.timeScale = 0;
            m_slider.transform.localPosition = new Vector3(0, 0, 0);
            m_text.transform.localPosition = new Vector3(60, 20, 0);
            m_button.transform.localPosition = new Vector3(1, -68, 0);
        }

        else
        {
            m_slider.transform.localPosition = new Vector3(1000, 1000, 1000);

            Time.timeScale = 1;
            m_text.transform.localPosition = new Vector3(1000, 1000, 1000);
            m_button.transform.localPosition = new Vector3(1000, 1000, 1000);
        }
    }
    

}

