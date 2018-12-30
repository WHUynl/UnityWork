using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public Transform m_canvas_main;//游戏场景的canvas
    public float theTime = 0f;//开始的时间
    public Text m_text_time;//时间

    void Start()
    {
        m_text_time.text = string.Format("TIME:{0}", theTime);
    }

    void Update()
    {

        if (GameManager.Instance.m_isAlive)
        {
            StartTime();
        }
        m_text_time.text = string.Format("TIME:{0}", (int)theTime);

    }

    void StartTime()
    {
        theTime += Time.deltaTime;
    }
}
